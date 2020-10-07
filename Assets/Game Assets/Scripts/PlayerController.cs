using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int amtOfJumps, lives;
    public float playerSpeed, playerJumpForce, groundCheckRadius , SecsToGameOverUI, knockBackSpeed;
    public Transform boundryPosition, groundCheck;
    public LayerMask whatIsGround;

    [SerializeField]
    private BoxCollider2D StandingCol, CrouchCol;

    private int amtOfJumpsLeft, livesleft;
    private float speed;
    private bool IsCrouching = false, canMove = true,  isGrounded, outOfBoundry = false;
    private Animator playerAnim;
    private Rigidbody2D plRb;

    [SerializeField]
    private ScoreController scorecontroller;
    [SerializeField]
    private GameOverController gameOver;
    [SerializeField]
    private PlayerHeartsController heartsController;
    [SerializeField]
    private GameObject hearts;


    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        plRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        amtOfJumpsLeft = amtOfJumps;
        livesleft = lives;

    }
    // Update is called once per frame
    void Update()
    {
        PlayerDirection();
        Crouch();
        if (plRb.position.y < boundryPosition.position.y)
        {
            if (outOfBoundry == false)
            {
                outOfBoundry = true;
                OutOfBounds();
            }
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

    public void LoadAnyLevel(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
    public void DecreaseLives()
    {
        livesleft--;
        heartsController.heartlost(livesleft);
        if (livesleft <= 0)
            KillPlayer();
    }
    public void KillPlayer()
    {
        playerAnim.SetTrigger("Death");
        StartCoroutine(SecsGapToGameOver(SecsToGameOverUI));
        canMove = false;
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