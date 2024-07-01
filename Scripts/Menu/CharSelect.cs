using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharSelect : MonoBehaviour
{
    private int index;
    [SerializeField] GameObject[] character;
    [SerializeField] TextMeshProUGUI charName;

    [SerializeField] GameObject[] charPrefaps;
    public static GameObject selectedChar;
    public static int Cindex;

    private void Start()
    {
        index = 0;
        SelectCharacter();
    }
    public void OnleftBtn()
    {
        if (index > 0)
        {
            index --;
        }
        else
        {
            index = character.Length-1;
        }
        SelectCharacter();
    }
    public void OnRightbtn()
    {
        if(index < character.Length-1)
        {
            index ++;
        }
        else
        {
            index = 0;
        }
        SelectCharacter();
    }
    public void SelectCharacter()
    {
        for(int i = 0;i<character.Length;i++) {
            if (i == index)
            {
                character[i].SetActive(true);
                character[i].GetComponent<SpriteRenderer>().color = Color.white;
                character[i].GetComponent<Animator>().enabled = true;
                selectedChar = charPrefaps[i];
                charName.text = charPrefaps[i].name;
                Cindex = i;
            }
            else
            {
                character[i].SetActive(false);
            }
        }
        
    }
}

