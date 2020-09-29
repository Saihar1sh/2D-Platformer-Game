using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed, playerJumpForce;

    [SerializeField]
    private BoxCollider2D StandingCol, CrouchCol, LvlCompleteCol;

    private float horizontal;
    private bool IsCrouching = false, canMove = true;
    private Animator playerAnim;
    private Rigidbody2D plRb;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        plRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMvt();
        PlayerDirection();
        Crouch();
        Jump();
    }

    private void PlayerMvt()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (canMove)
        {
            playerAnim.SetFloat("Speed", Mathf.Abs(horizontal));
            Vector3 position = transform.position;
            position.x +=  horizontal * playerSpeed * Time.deltaTime;
            transform.position = position;
        }
    }

    private void PlayerDirection()
    {
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (horizontal > 0)
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
        float jump = Input.GetAxisRaw("Jump");
        playerAnim.SetFloat("jump", jump);

        if (jump > 0)
        {
            plRb.AddForce(new Vector2(0.0f, playerJumpForce), ForceMode2D.Force);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LvlComplete"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}