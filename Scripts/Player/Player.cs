using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;
    private int[] a = new int[2];
    public float moveSpeed = 200f;
    private Rigidbody rb;
    public Vector3 moveInputl;
    public SpriteRenderer CR;
    public Animator animator;
   
    public float dashBoost = 200f;
    private float dashTime;
    public float DashTime;
    private bool once;
    public Health playerHealth;
    public int money;
    public Transform throwPoint;
    public GameObject[] weapons; // Mảng chứa các prefab vũ khí
    private int currentWeaponIndex = 0; // Chỉ số của vũ khí hiện tại
    private GameObject currentWeapon; // Tham chiếu đến vũ khí hiện tại
    public GameObject grenadePrefab;
    
    public float throwForce = 20f;

    private void Awake()
    {
        if(instance != null&&instance!=this)
        {
            Destroy(this );
        }
        else
        {
            instance = this;
        }
       
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        a[0] = weapons[0].GetComponent<weapon>().QuantityBullet;
        a[1] = weapons[1].GetComponent<weapon>().QuantityBullet;
        Debug.Log("a0: " + a[0]);
        Debug.Log("a1: " + a[1]);
        
        EquipWeapon(currentWeaponIndex);
       
    }

    private void Update()
    {
        moveInputl.x = Input.GetAxis("Horizontal");
        moveInputl.y = Input.GetAxis("Vertical");
        transform.position += moveSpeed * moveInputl * Time.deltaTime;
        animator.SetFloat("Speed", moveInputl.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0)
        {
            animator.SetBool("Roll", true);
            moveSpeed = moveSpeed + dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            animator.SetBool("Roll", false);
            moveSpeed = moveSpeed - dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }


        if (moveInputl.x != 0)
        {
            if(moveInputl.x > 0)
            {
                CR.transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                CR.transform.localScale = new Vector3(-1, 1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(ShopManager.i >0)
            {
                ShopManager.i--;
                playerHealth.currentHealth += 20;
                playerHealth.healthBar.UpdateHealth(playerHealth.currentHealth, playerHealth.maxHealth);
                Debug.Log("h= "+playerHealth.currentHealth);
                if(playerHealth.currentHealth > 100)
                {
                    playerHealth.currentHealth = 100;
                    playerHealth.healthBar.UpdateHealth(playerHealth.currentHealth, playerHealth.maxHealth);
                }
                ScoreManager.Instance.UpdateQuantity();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (ShopManager.m > 0)
            {
                ShopManager.m--;
                currentWeapon.GetComponent<weapon>().QuantityBullet = currentWeapon.GetComponent<weapon>().Max;
                ScoreManager.Instance.UpdateAmm();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            a[1] = currentWeapon.GetComponent<weapon>().QuantityBullet;
            SwitchWeapon(0);
            
            Debug.Log("a0: " + a[0]);
            Debug.Log("a1: " + a[1]);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            a[0] = currentWeapon.GetComponent<weapon>().QuantityBullet;
            SwitchWeapon(1);
            
            Debug.Log("a0: " + a[0]);
            Debug.Log("a1: " + a[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (ShopManager.l > 0)
            {
                ShopManager.l--;
                ThrowGrenade();
                ScoreManager.Instance.UpdateGre();
            }


        }



        }
    void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weapons.Length)
        {
            EquipWeapon(weaponIndex);

        }
    }
    public void TakeDame(int damage)
    {
        playerHealth.TakeDam(damage);
        
    }
    public void EquipWeapon(int index)
    {
      
        Vector3 x = new Vector3(0, 60, 0);
        
        if (currentWeapon != null)
        {
            
            Destroy(currentWeapon);
            
        }

        // Trang bị vũ khí mới
        currentWeapon = Instantiate(weapons[index], (this.transform.position - x), this.transform.rotation, this.transform);
        currentWeaponIndex = index;
        currentWeapon.GetComponent<weapon>().QuantityBullet = a[index];

    }
    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        rb.AddForce(this.transform.right * throwForce, ForceMode2D.Impulse);
       
    }
}
