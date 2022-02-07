using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    /// <summary> 월드 씬으로 넘어간다
    public void StartGame()
    {
       
        Debug.Log("게임 시작");
        SceneManager.LoadScene("World");
    }

    /// <summary> 게임을 종료한다.
    public void ExitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
