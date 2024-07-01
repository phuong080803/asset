using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject Butllet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float ButlletForce,spread ;
    private float timeBtwFire;
    public GameObject muzzle;
    public bool isShotGun;
    public int amountOfBullet;
    public int price;
    public int Max;
    public int QuantityBullet;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        
        ScoreManager.Instance.QuantityB(QuantityBullet);
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        
        if (Input.GetMouseButton(0)&& timeBtwFire < 0)
        {
            
            if (QuantityBullet > 0)
            {
                audioManager.PlaySFX(audioManager.fire);
                fireBullet();
                QuantityBullet--;
                ScoreManager.Instance.QuantityB(QuantityBullet);
            }
        }
       
    }
    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler( 0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z>90 && transform.eulerAngles.z < 270)
        {
            transform.localScale =new Vector3(1.2f, -1.2f ,0);
        }
        else
        {
            transform.localScale =new  Vector3(1.2f, 1.2f ,0);
        }
    }
    void fireBullet()
    {
        timeBtwFire = TimeBtwFire;
        if(isShotGun==false) {

            GameObject bullet = Instantiate(Butllet, firePos.position, Quaternion.identity);
            Instantiate(muzzle, firePos.position, transform.rotation, transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * ButlletForce, ForceMode2D.Impulse);
        }
        else
        {
            for (int i = 0; i < amountOfBullet; i++)
            {
                GameObject bullet = Instantiate(Butllet, firePos.position, firePos.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                // Tính toán hướng bắn
                Vector2 dir = transform.rotation * Vector2.right;
                Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
                Vector2 finalDir = (dir + pdir).normalized;

                // Áp dụng lực cho đạn
                rb.AddForce(finalDir * ButlletForce, ForceMode2D.Impulse);
            }
        }
    }

}
