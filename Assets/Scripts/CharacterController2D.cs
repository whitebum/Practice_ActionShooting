using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    /// <summary>
    /// 캐릭터를 이동시키기 위한 입력값
    /// </summary>
    [Header("Input")]
    public Vector2 input;

    [Header("Movement")]
    public float speed = 10;

    [Header("Jumping")]
    public float jumpPower = 5;
    public int jumpCount = 1;
    private int currentJumpCounter = 0;

    private bool isGrounded;

    private Rigidbody2D rb2D;
    private Animator animator;

    /// <summary>
    /// 게임 오브젝트가 최초로 활성화될 때 등장하는 함수
    /// </summary>
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1.005f),
                                             Vector2.down, 0.05f,
                                             LayerMask.GetMask("Tile", "Default"));
        
        isGrounded = false;
        if (hit)
        {
            if(rb2D.velocity.y <= 0.1f)
            {
                //Debug.Log("바닥에 닿음");
                currentJumpCounter = 0;
                isGrounded = true;
            }
        }

        // 좌-우 입력을 받는다
        // float inputX = Input.GetAxis("Horizontal");
        float inputX = input.x;

        // 받은 입력에 따라 힘을 가한다
        Vector2 velocity = rb2D.velocity;
        velocity.x = inputX * speed;
        rb2D.velocity = velocity;

        // 입력에 따라 방향 변경
        if (Mathf.Abs(inputX) > 0.1f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(inputX);
            transform.localScale = scale;
        }

        // 입력에 따라 애니메이션 파라미터 전달
        animator.SetBool("IsMoving", (Mathf.Abs(inputX) > 0.1f));
        animator.SetBool("IsGrounded", isGrounded);
    }

    public void Jump()
    {
        if (currentJumpCounter < jumpCount)
        {
            currentJumpCounter++;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
        }
    }
}
