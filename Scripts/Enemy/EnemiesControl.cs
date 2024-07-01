using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesControl : MonoBehaviour
{
    Player playerS;
    public int minDamage;
    public int maxDamage;
    public Health ehealth;

 
    [SerializeField] GameObject FT;
    public FloatingTextManager floatingTextManager;
    private void Start()
    {
        ehealth = GetComponent<Health>();
        floatingTextManager = FindObjectOfType<FloatingTextManager>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = collision.GetComponent<Player>();
            InvokeRepeating("DamePayer", 0, 0.1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerS = null;
            CancelInvoke("DamePayer");
        }
    }
    
    void DamePayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        playerS.TakeDame(damage);
        
    }
    public void TakeDame(int damage)
    {
        
        ehealth.TakeDam(damage);
       
    }
   
}
