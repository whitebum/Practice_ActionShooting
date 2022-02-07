using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UIResultPanel resultPanel;

    public Creature player;

    public int Score = 0;

    public bool isGameOver;

    // ���� ������ �� �帥 �ð�
    public float gameTimer;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            gameTimer += Time.deltaTime;

            if (!player)
            {
                resultPanel.OpenPanel(false);
                isGameOver = true;
            }
        }
    }

    public void Victory()
    {
        if(!isGameOver)
        {
            resultPanel.OpenPanel(true);
            isGameOver = true;
        }
    }
}
