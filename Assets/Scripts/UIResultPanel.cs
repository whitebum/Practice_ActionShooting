using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIResultPanel : MonoBehaviour
{
    public Text scoreText;

    /// <summary>
    /// �÷��̾� ��� â
    /// </summary>
    /// <param name="victory">�¸� : true, �й� : false</param>
    public void OpenPanel(bool victory)
    {
        gameObject.SetActive(true);

        if (victory)
        {
            // ������ ��� �� ���ھ ǥ��
            int totalScore = GameManager.Instance.Score - (int)(GameManager.Instance.gameTimer * 50);

            if (totalScore < 0) { totalScore = 0; }

            scoreText.text = totalScore.ToString();
        }

        else
            scoreText.text = "DIED";
    }

    public void ExitGame()
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("Title");
    }
}
