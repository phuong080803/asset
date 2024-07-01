using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayControl : MonoBehaviour
{

    [SerializeField]private GameObject PausePanel;
    public void PauseGameBtn()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeBtn()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResetBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
