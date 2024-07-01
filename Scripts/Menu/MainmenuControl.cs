using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MainmenuControl : MonoBehaviour
{
    public GameObject Charracter;
    public GameObject Shop;
    public GameObject exitBtn;
    public void PlayButton()
    {
        Application.LoadLevel("GamePlay");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
    }
    public void QuitGameButon()
    {
        Application.Quit();
    }
    public void HomeBtn()
    {
        Application.LoadLevel("Main Menu");
    }
    public void PauseBtn()
    {
        Application.LoadLevel("Pause");
    }
    public void ShopBtn() {
        Charracter.SetActive(false);
        Shop.SetActive(true);
        exitBtn.SetActive(true);
    }
    public void ExitBtn()
    {

        Charracter.SetActive(true);
        Shop.SetActive(false);
        exitBtn.SetActive(false);
    }

}
