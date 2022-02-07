using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Attack Speed")]
    public float attackIntervalTime = 0.15f;
    private float attackTimer = 0;

    public bool isAttacking;
    public int numOfAttack = 4;
    private int attackCounter = 0;

    public Transform fireTransform;
    public GameObject bulletPrefab;

    /// <summary>
    /// 위를 조준하는가를 판단하는 변수
    /// </summary>
    private bool isAimToUp;

    private void Update()
    {
        float axis = Input.GetAxis("Vertical");
        
        if (axis > 0) isAimToUp = true;
        else isAimToUp = false;

        if (isAimToUp)
            transform.localEulerAngles = new Vector3(0, 0, 90);

        else
            transform.localEulerAngles = new Vector3(0, 0, 0);

        if (Input.GetButtonDown("Fire1"))
            isAttacking = true;

        attackTimer += Time.deltaTime;
        // 공격 요청이 오면 정해진 횟수/간격대로 총알을 발사
        if (isAttacking)
        {
            if (attackTimer > attackIntervalTime)
            {
                attackTimer = 0;
               
                FireBullet();

                ++attackCounter;
                if(attackCounter > numOfAttack)
                {
                    isAttacking = false;
                    attackCounter = 0;
                }
            }
        }
    }

    private void FireBullet()
    {
        //BANG
        GameObject obj = Instantiate(bulletPrefab, fireTransform.position, Quaternion.identity);

        Bullet bullet = obj.GetComponent<Bullet>();

        Vector3 bulletDir;
        if (isAimToUp) bulletDir = Vector3.up;
        else bulletDir = Vector3.right * transform.lossyScale.x;

        bullet.Initialize(bulletDir, ETeam.Enemy);
    }
}
