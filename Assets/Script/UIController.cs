using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject settingPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
    public void ìnfo()
    {
        SceneManager.LoadScene("InfoGroup");
        Time.timeScale = 1.0f;
    }
    public void closeSetting()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void openSetting()
    {
        settingPanel.SetActive(true);
    }
    public void pauseSetting()
    {
        Time.timeScale = 0f;
        settingPanel.SetActive(true);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
