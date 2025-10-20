using UnityEngine;

// 현재는 단일 플레이어 테스트를 위해 MonoBehaviour를 상속합니다.
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    public float jumpForce = 8f; // 점프 힘

    private Rigidbody2D rb; // Rigidbody2D 컴포넌트 참조

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f; // 땅 감지 반경
    
    // 점프 디버깅을 위해 public으로 유지합니다. (Is Grounded 체크박스)
    public bool isGrounded; 

    void Start()
    {
        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();
        
        // Rigidbody2D가 null인지 확인하는 것이 좋습니다.
        if (rb == null)
        {
            Debug.LogError("PlayerMovement: Rigidbody2D 컴포넌트가 Player 오브젝트에 없습니다.");
        }
    }

    void Update()
    {
      
        // ------------------- 디버그 코드 추가 -------------------
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("키 입력 감지됨! Time: " + Time.time);
        }
        // ----------------------------------------------------

        // 1. 땅 감지...
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 2. 점프 입력 처리...
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        
        // 1. 땅 감지 (점프 가능 여부 확인)
        // groundCheck 위치에서 groundCheckRadius 반경 내에 groundLayer가 감지되면 true
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 2. 점프 입력 처리 (Spacebar)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 위쪽 방향으로 점프 힘 적용
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // 3. 좌우 이동 입력 처리 (A/D 키)
        // Input.GetAxisRaw("Horizontal")은 A키(-1), D키(1), 또는 입력 없을 때(0)를 반환합니다.
        float moveInput = Input.GetAxisRaw("Horizontal"); 

        // x축 속도 설정
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        
        // 4. 캐릭터 좌우 방향 전환 (6단계에서 추가 논의된 내용)
        if (moveInput != 0) // 이동 입력이 있을 때만
        {
            Vector3 newScale = transform.localScale;
            
            if (moveInput > 0) // 오른쪽 이동 (D)
            {
                newScale.x = Mathf.Abs(newScale.x); // 양수 스케일
            }
            else if (moveInput < 0) // 왼쪽 이동 (A)
            {
                newScale.x = -Mathf.Abs(newScale.x); // 음수 스케일 (반전)
            }
            
            transform.localScale = newScale;
        }

        float moveInput = Input.GetAxisRaw("Horizontal"); 

        if (moveInput != 0) // 이동 입력이 있을 때만
        {
            Vector3 newScale = transform.localScale;
            
            if (moveInput > 0) // 오른쪽 이동 (D)
            {
                newScale.x = Mathf.Abs(newScale.x); // 양수 스케일 유지
            }
            else if (moveInput < 0) // 왼쪽 이동 (A)
            {
                newScale.x = -Mathf.Abs(newScale.x); // 음수 스케일 (반전)
            }
            
            transform.localScale = newScale;
        }
    }
}