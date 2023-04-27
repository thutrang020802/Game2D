using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // khởi tạo các conponent của player
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    // layer sử lí nhẩy
    [SerializeField] private LayerMask jumpableGround;
        
    private float directionX = 0f; // hướng của player
    [SerializeField] private float moveSpeed = 7f; // tốc độ di chuyển
    [SerializeField] private float jumpForce = 14f; // lực nhảy

    // trạng thái của player
    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        // lấy component ra
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal"); // input A & D
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y); // di chuyển trục X

        if (Input.GetButtonDown("Jump") && IsGrounded() == true) // ấn Space để nhảy, chạm ground mới cho nhảy tiếp
        {
            FindObjectOfType<AudioManager>().PlayOneShot("jump", 0.5f);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // add lực đẩy trục Y
        }
        UpdateAnimationState();
    }
    
    private void UpdateAnimationState() // sử lí animatin cho player
    {
        MovementState state;

        if (directionX > 0f) // hướng bên phải
        {
            state = MovementState.running;
            sprite.flipX = false; // quay mặt bên phải
        }
        else if (directionX < 0f) // hướng bên trái
        {
            state = MovementState.running;
            sprite.flipX = true; // quay mặt bên trái
        }
        else
        {
            // đứng im
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            // khi nhảy
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            // khi rơi
            state = MovementState.falling;
        }

        // set aimation theo state
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        // check chạm ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
