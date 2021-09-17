using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject ingameMenu;
    public bool isopen;
    // Start is called before the first frame update
    void Start()
    {
        ingameMenu.SetActive(false);
        isopen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //开始游戏按钮实现
    public void BeginClick()
    {
        SceneManager.LoadScene("VillageScene");
    }
    //返回按钮实现
    public void ReturnClick()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
        //SceneManager.LoadScene("MainMenu");
    }
    //暂停按钮实现
    public void PauseClick()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }
    //退出按钮实现
    public void ExitClick()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
        //Application.Quit();
    }

    public void ReStartClick()
    {
        SceneManager.LoadScene("VillageScene");
        Time.timeScale = 1f;
    }

    public void MenuClick()
    {
        isopen = !isopen;
        ingameMenu.SetActive(isopen);
    }

    public void ContinuingClick()
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }

    public void ExitOnOK()
    {
        Application.Quit();
    }

    public void ReturnOnOk()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReStart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
