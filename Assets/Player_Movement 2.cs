using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    public float jumpForce = 8f; // 점프 힘

    private Rigidbody2D rb; // Rigidbody2D 컴포넌트 참조
    private bool isGrounded; // 땅에 닿았는지 확인하는 플래그 (점프 제어용)
    
    // 땅 감지를 위한 변수
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f; // 땅 감지 반경

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. 땅 감지 (점프 가능 여부 확인)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 2. 점프 입력 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 위쪽 방향으로 점프 힘 적용
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // 3. 좌우 이동 입력 처리 (물리 업데이트는 FixedUpdate에서 처리)
        float moveInput = Input.GetAxisRaw("Horizontal"); // A(-1) 또는 D(1) 또는 0

        // x축 속도 설정
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}