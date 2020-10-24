using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int amtOfJumps, lives;
    public float playerSpeed, playerJumpForce, groundCheckRadius , SecsToGameOverUI;
    public Transform boundryPosition, groundCheck;
    public LayerMask whatIsGround;

    [SerializeField]
    private int amtOfJumpsLeft, livesleft,a;
    private float speed, jump;
    private bool IsCrouching = false, canMove = true, canJump =true, isGrounded, outOfBoundry = false;
    private Animator playerAnim;
    private Rigidbody2D plRb;
    private CapsuleCollider2D capsuleCollider2D;

    [SerializeField]
    private ScoreController scorecontroller;
    [SerializeField]
    private GameOverController gameOver;
    [SerializeField]
    private PlayerHeartsController heartsController;
    [SerializeField]
    private GameObject hearts;
    [SerializeField]
    private PauseMenu pauseMenu;


    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        plRb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        amtOfJumpsLeft = amtOfJumps;
        livesleft = lives;
        //transform.position = LevelManager.Instance.lastCheckptPos;
        //Debug.Log("Player last checkpt set");

    }
    // Update is called once per frame
    void Update()
    {
        UpdatePlayerAnimations();
        Crouch();
        if (plRb.position.y < boundryPosition.position.y)
        {
            if (outOfBoundry == false)
            {
                outOfBoundry = true;
                OutOfBounds();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.MenuEnable();
        }

    }
    private void FixedUpdate()
    {
        PlayerInput();
        PlayerDirection();
        Jump();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    private void PlayerInput()
    {
        speed = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxis("Jump");
        if (canMove)
        {
            PlayerMvt();
        }

    }
    private void UpdatePlayerAnimations()
    {
        playerAnim.SetFloat("Speed", Mathf.Abs(speed));
        playerAnim.SetFloat("VerticalSpeed", plRb.velocity.y);
        playerAnim.SetFloat("jump", jump);
        playerAnim.SetBool("isCrouching", IsCrouching);

    }
    private void PlayerMvt()
    {       
            Vector3 position = transform.position;
            position.x += speed * playerSpeed * Time.deltaTime;
            transform.position = position;
          
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
            playerAnim.SetTrigger("crouch");
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


    }
    private void Jump()
    {
        if (isGrounded && canJump)
        {
            amtOfJumpsLeft = amtOfJumps;
        }
        if (amtOfJumpsLeft > 0)
        {
            if (jump > 0)
            {
                plRb.AddForce(new Vector2(0.0f, playerJumpForce), ForceMode2D.Force);
                amtOfJumpsLeft--;
            }
        }
    }
    private void OutOfBounds()
    {
        Debug.Log("Out of Bonds");
        canMove = false;
        Debug.Log("Player Died........Scene restarting");
        KillPlayer();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public void PickupKey()
    {
        Debug.Log("Picked up key");
        scorecontroller.IncreaseScore(10);
    }
    public void TelportTo(Vector2 teleportPosition)
    {
        transform.position = teleportPosition;
    }
    public void LoadAnyLevel(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
    public void DecreaseLives()
    {
        livesleft--;
        if (livesleft > 0)
        {
            playerAnim.SetTrigger("Hurt");
            heartsController.heartlost(livesleft);
        }
        else if (livesleft <= 0)
            KillPlayer();
    }
    public void KillPlayer()
    {
        canMove = false;
        canJump = false;
        heartsController.heartlost(0);
        playerAnim.SetTrigger("Death");
        StartCoroutine(SecsGapToGameOver(SecsToGameOverUI));
    }
    
    private IEnumerator SecsGapToGameOver(float secs)
    {
        Debug.Log(secs + " Secs timer start");
        yield return new WaitForSeconds(secs);
        Debug.Log(secs + " Secs completed");
        gameOver.PlayerDied();
        hearts.SetActive(false);
        this.enabled = false;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HiddenArea"))
            collision.gameObject.SetActive(false);
    }
}