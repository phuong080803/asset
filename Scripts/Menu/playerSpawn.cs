using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    public GameObject LosePanel;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject[] PPanle;

    void Start()
    {
        GameObject selectedCharacer = CharSelect.selectedChar;
        Instantiate(selectedCharacer, transform.position, Quaternion.identity);
        virtualCamera.Follow = Player.instance.transform;
        virtualCamera.LookAt = Player.instance.transform;
        for(int i = 0; i < PPanle.Length; i++)
        {
            if (i == CharSelect.Cindex)
            {
                PPanle[i].SetActive(true);
            }
            else
            {
                PPanle[i].SetActive(false);
            }
        }
    

    }
    

}
