using UnityEngine;
using static GameManager;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;
    public bool isGrounded = true;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance.currentState != GameState.Playing)
            return;

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // 바닥에 닿았을 때
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("장애물과 충돌!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("아이템 획득!");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Danger"))
        {
            Debug.Log("위험!");
        }
    }
}
