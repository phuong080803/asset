using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopManager : MonoBehaviour
{
    public  int[,] shopItems = new int[5, 5];
    public GameObject Shop;
    public GameObject Charracter;
    public static int i,k,l,m;
   

    public void Start()
    {
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }


    public void BuyBtn()
    {
        GameObject Btn = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        
        if(ScoreManager.allGold >= shopItems[2, Btn.GetComponent<BtnInfor>().ItemID])
        {
            ScoreManager.allGold -= shopItems[2, Btn.GetComponent<BtnInfor>().ItemID];
            shopItems[3, Btn.GetComponent<BtnInfor>().ItemID]++;
            
            Btn.GetComponent<BtnInfor>().QuantityTxt.text = shopItems[3, Btn.GetComponent<BtnInfor>().ItemID].ToString();
            ScoreManager.Instance.UpdateAllGold();
            switch (Btn.GetComponent<BtnInfor>().ItemID)
            {
                case 1:
                    i = shopItems[3, 1];
                    break;
                case 2:
                    Player.instance.playerHealth.maxHealth += 20;
                    break;
                case 3:
                    m += shopItems[3, 3];
                    break;
                case 4:
                    l += shopItems[3, 4];
                    break;
            }
        }

        


    }
    
    public void selectBtn()
    {


    }


}
