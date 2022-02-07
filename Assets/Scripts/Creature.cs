using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETeam
{
    Player, Enemy, 
}

public class Creature : MonoBehaviour
{
    public ETeam team;
    public int hp = 100;
    public int maxhp = 0;

    private void Start()
    {
        maxhp = hp;
    }

    /// <summary>
    /// 데미지를 받는다
    /// </summary>
    /// <param name="damage">객체가 받은 데미지</param>
    public void ApplyDamage(int damage)
    {
        hp -= damage;

        if(team == ETeam.Enemy)
        {
            GameManager.Instance.Score += 1500;
        }

        if(hp <= 0)
        {
            // 죽음
            Destroy(gameObject);
        }
    }
}