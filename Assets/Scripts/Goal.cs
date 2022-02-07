using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public UIResultPanel resultPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform == GameManager.Instance.player.transform)
        {
            GameManager.Instance.Victory();
            Debug.Log("게임 클리어");
        }
    }
}
