using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    /// <summary>
    /// ĳ���͸� �̵���Ű�� ���� �Է°�
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
    /// ���� ������Ʈ�� ���ʷ� Ȱ��ȭ�� �� �����ϴ� �Լ�
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
                //Debug.Log("�ٴڿ� ����");
                currentJumpCounter = 0;
                isGrounded = true;
            }
        }

        // ��-�� �Է��� �޴´�
        // float inputX = Input.GetAxis("Horizontal");
        float inputX = input.x;

        // ���� �Է¿� ���� ���� ���Ѵ�
        Vector2 velocity = rb2D.velocity;
        velocity.x = inputX * speed;
        rb2D.velocity = velocity;

        // �Է¿� ���� ���� ����
        if (Mathf.Abs(inputX) > 0.1f)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(inputX);
            transform.localScale = scale;
        }

        // �Է¿� ���� �ִϸ��̼� �Ķ���� ����
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
