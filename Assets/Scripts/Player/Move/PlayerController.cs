using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool canDoubleJump;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isRed;
    public int score;


    public GameObject playerPos;



    PlayerColor playerColor;

    private void Awake()
    {
        transform.position = playerPos.transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        // 좌우 이동
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                DoubleJump();
                canDoubleJump = false;
            }
        }

        if(transform.position.x<-8.8f || transform.position.x > 8.8f)
        {
            GameManager.Instance.GameOver();
            Debug.Log("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameManager.Instance.GameOver();
        }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canDoubleJump = true;
    }

    void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
        }
       
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

