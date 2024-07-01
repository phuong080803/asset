using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public GameObject ScoreCanvas;
    public GameObject CoinCanvas;
    private int score;
    private int gold;
    public TextMeshProUGUI scoreText;  // Text UI để hiển thị điểm
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI AllgoldText;
    public TextMeshProUGUI HighScore;
    public GameObject item;
    public TextMeshProUGUI itemQuantity;
   
    public int itemCount;
    public  int highScore;
    public static int allGold ;
    int x;
    public TextMeshProUGUI Bullet;
    public TextMeshProUGUI Ammobox;
    public TextMeshProUGUI Grenade;
    public int Bq;
    public int AmmQ;
    public int GreQ;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        UpdateGoldText();
        UpdateHighScore();
        UpdateAllGold();
        UpdateQuantity();
        UpdateBullet();
        UpdateAmm();
        UpdateGre();

    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }
    
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
            x = score;
        }
        if (highScore == 0)
        {
            highScore = x;
            UpdateHighScore();
        }
        else
        {
            if (highScore < x)
            {
                highScore = x;
                UpdateHighScore();
            }
        }
        Debug.Log("h = " + highScore);
        
    }
    public void AddGold(int Gold)
    {
        gold += Gold;
        UpdateGoldText();
        allGold += Gold;
        UpdateAllGold();
    }
    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + gold.ToString();
        }
    }
    private void UpdateHighScore()
    {
        if (HighScore != null)
        {
            HighScore.text = "High Score : " + highScore.ToString();
        }
    }
    public void UpdateAllGold()
    {
      
        if (AllgoldText != null)
        {
            AllgoldText.text = ": " + allGold.ToString();
            Debug.Log(allGold);
        }
    }
    
    public void UpdateQuantity()
    {
        if (itemQuantity != null)
        {
            itemQuantity.text =  ShopManager.i.ToString();
        }
    }
    public void QuantityB(int BQuantity)
    {
        Bq = BQuantity;
        UpdateBullet();

    }
  
    private void UpdateBullet()
    {
        if (Bullet != null)
        {
            
            Bullet.text = Bq.ToString();
        }
    }
    public void UpdateAmm()
    {
        if (Ammobox != null)
        {

            Ammobox.text = ShopManager.m.ToString();
        }
    }
    public void UpdateGre()
    {
        if (Ammobox != null)
        {

            Grenade.text = ShopManager.l.ToString();
        }
    }

}
