using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    /// <summary> ���� ������ �Ѿ��
    public void StartGame()
    {
       
        Debug.Log("���� ����");
        SceneManager.LoadScene("World");
    }

    /// <summary> ������ �����Ѵ�.
    public void ExitGame()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }
}
