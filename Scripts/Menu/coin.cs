using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class coin : MonoBehaviour
{
    public int pointValue = 10;  // Giá trị điểm của item
    Player playerS;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddGold(pointValue);
            Destroy(gameObject);
        }
    }
   


}
