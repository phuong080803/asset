using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butllet : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool PBullet;
    [SerializeField] private PopupManager popupManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") && PBullet == false)
        {
            int damage = Random.Range(minDamage, maxDamage);
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDame(damage);
                Debug.Log("take dame" + damage);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Enemies") && PBullet == true)
        {
            int damage = Random.Range(minDamage, maxDamage);
            
            EnemiesControl enemy = collision.GetComponent<EnemiesControl>();
            if (enemy != null)
            {
                enemy.TakeDame(damage);
                Destroy(gameObject);               
            }
        }
    }
}
