using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Skeleton : MonoBehaviour
{
    public float sightRange = 5;
    public int damage = 10;

    // FSM : 유한상태기계
    private Creature target;

    private Creature myCreature;
    private CharacterController2D myController;

    private void Awake()
    {
        myCreature = GetComponent<Creature>();
        myController = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if(!target)
        {
            // 타깃을 찾는다.
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,
                                                          sightRange,
                                                          Vector2.zero,
                                                          0,
                                                          LayerMask.GetMask("Default"));

            foreach(RaycastHit2D hit in hits)
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
            // 타깃을 향해 달려온다.
            float dir = target.transform.position.x - transform.position.x;

            dir = Mathf.Sign(dir);
            myController.input.x = dir;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Creature creature = collision.collider.GetComponent<Creature>();

        if(creature)
        {
            if(creature.team != myCreature.team)
            {
                creature.ApplyDamage(damage);
            }
        }
    }
}
