using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ �Ѿ˷� �����ϴ� ������ �ൿ ����
/// </summary>
public class Monster_Bat : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    private Vector2 moveDir;
    public float changeMoveTime = 1.0f;
    private float changeMoveTimer = 0;

    public float sightRange = 5f;

    public GameObject bulletPrefab;

    public float attackIntervalTime = 1.0f;

    private float attackTimer = 0.0f;

    private Rigidbody2D myRigidbody2D;
    private Creature myCreature;
    private Creature target;

    private void Awake()
    {
        myCreature = GetComponent<Creature>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        changeMoveTimer += Time.deltaTime;
        if(changeMoveTimer > changeMoveTime)
        {
            changeMoveTimer = 0;
            // ���� �ֱ⸶�� ������ �̵� ��θ� ������.
            moveDir = Random.insideUnitCircle * speed;
        }

        myRigidbody2D.velocity = moveDir;

        if (!target)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, sightRange, Vector2.zero, 0, LayerMask.GetMask("Default"));

            foreach (var hit in hits)
            {
                Creature creature = hit.transform.GetComponent<Creature>();

                if (creature)
                {
                    if (creature.team != myCreature.team)
                    {
                        target = creature;
                        break;
                    }
                }
            }
        }

        else
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackIntervalTime)
            {
                attackTimer = 0;
                // BANG
                GameObject obj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                Bullet bullet = obj.GetComponent<Bullet>();

                Vector3 dir = target.transform.position - transform.position;
                bullet.Initialize(dir, ETeam.Player);
            }

            if (Vector2.Distance(transform.position, target.transform.position) > sightRange)
            {
                target = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
