using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 moveDir;

    private ETeam target;

    public float speed = 10.0f;
    public float deleteTime = 0.9f;

    [Header("Destroy")]
    public float destroyTime = 0.4f;
    private float destroyTimer = 0.0f;

    private void Update()
    {
        transform.Translate(speed * moveDir.normalized * Time.deltaTime);

        destroyTimer += Time.deltaTime;

        if (destroyTimer > destroyTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Creature creature = collision.GetComponent<Creature>();
        
        if(creature)
        {
            if (creature.team == target)
            {
                creature.ApplyDamage(10);
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 총알을 초기화하는 함수
    /// </summary>
    /// <param name="direction">방향 (어느 음수, 혹은 양수)</param>
    public void Initialize(Vector3 direction, ETeam target)
    {
        this.target = target;
        moveDir = direction;
    }
}
