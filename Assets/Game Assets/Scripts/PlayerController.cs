using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int amtOfJumps;
    public float playerSpeed, playerJumpForce, groundCheckRadius;
    public Transform boundryPosition, groundCheck;
    public LayerMask whatIsGround;

    [SerializeField]
    private BoxCollider2D StandingCol, CrouchCol;

    private int amtOfJumpsLeft;
    private float speed;
    private bool IsCrouching = false, canMove = true,  isGrounded;
    private Animator playerAnim;
    private Rigidbody2D plRb;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        plRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        amtOfJumpsLeft = amtOfJumps;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerDirection();
        Crouch();
        if (plRb.position.y < boundryPosition.position.y)
        {
            OutOfBounds();
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }
    private void FixedUpdate()
    {
        PlayerMvt();
        Jump();

    }

    private void PlayerMvt()
    {
        speed = Input.GetAxisRaw("Horizontal");
        if (canMove)
        {
            Vector3 position = transform.position;
            position.x += speed * playerSpeed * Time.deltaTime;
            transform.position = position;
            playerAnim.SetFloat("Speed", Mathf.Abs(speed));
           
        }
    }

    private void PlayerDirection()
    {
        Vector3 scale = transform.localScale;
        if (speed < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (speed > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            canMove = false;
            Debug.Log("getkeyDown");
            playerAnim.SetTrigger("crouching");
        }

        else if (Input.GetKey(KeyCode.LeftControl))
        {
            IsCrouching = true;
            Debug.Log("getkey");

        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = false;
            canMove = true;
            Debug.Log("getkeyup");
        }
        StandingCol.enabled = !IsCrouching;
        CrouchCol.enabled = IsCrouching;

        playerAnim.SetBool("isCrouching", IsCrouching);

    }
    private void Jump()
    {
        if (isGrounded)
        {
            amtOfJumpsLeft = amtOfJumps;
        }
        if (amtOfJumpsLeft > 0)
        {
            float jump = Input.GetAxis("Jump");
            playerAnim.SetFloat("jump", jump);
            if (jump > 0)
            {
                plRb.AddForce(new Vector2(0.0f, playerJumpForce), ForceMode2D.Force);
                amtOfJumpsLeft--;
            }
        }
    }

    
    void OutOfBounds()
    {
        Debug.Log("Out of Bonds");
        Debug.Log("Player Died........Scene restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}