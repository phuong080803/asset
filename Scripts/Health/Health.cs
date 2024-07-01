using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    
    public GameObject LosePanel;
    public int maxHealth;
    [HideInInspector] public int currentHealth;

    public HealthBar healthBar;
    public GameObject item;
    private float safeTime ;
    public float safeTimeDuration = 0f;
    
    public int pointValue;
    public bool camShake = false;
    public UnityEvent OnDeath;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);
    }

    public void Dead()
    {
        
 
        if(this.gameObject.tag == "Player")
        {
            OnDeath.Invoke();
            Destroy(gameObject);
            UiManager.Instance.losePanel.SetActive(true);
            Time.timeScale = 0f;
            ScoreManager.Instance.ScoreCanvas.SetActive(false);
            ScoreManager.Instance.CoinCanvas.SetActive(false);
        }
        
        
    }

    public void TakeDam(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;
            if (this.gameObject.tag == "Player")
            {
                audioManager.PlaySFX(audioManager.hit);
            }
                if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (this.gameObject.tag == "Enemies")
                {
                    Destroy(this.gameObject, 0.125f);
                    Instantiate(item, transform.position, Quaternion.identity);
                    ScoreManager.Instance.AddPoints(pointValue);
                    
                }
                Dead();
            }

            // If player then update health bar
            if (healthBar != null)
                healthBar.UpdateHealth(currentHealth, maxHealth);

            safeTime = safeTimeDuration;
        }
    }

    private void Update()
    {
        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }
        
    }
}