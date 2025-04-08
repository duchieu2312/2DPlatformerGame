using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject CreditUI;

    public void exitgame()
    {
        // Tắt game
        Application.Quit();
    }

    public void openCredit()
    {
        CreditUI.SetActive(true); // bật credit lên
    }

    public void closeCredit()
    {
        CreditUI.SetActive(false); // tắt credit
    }

    public void comeBackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        //Debug.Log("index="+SceneManager.GetActiveScene().buildIndex);
    }    

    public void BackToMenu()
    {
        SceneManager.LoadScene("SampleScene"); // Trở lại menu
    }
    public void startgame()
    {
        // ta sẽ tạo trước fucntion game;
        //Debug.Log("Game Start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}