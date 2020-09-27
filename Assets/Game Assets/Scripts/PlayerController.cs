﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    [SerializeField]
    private BoxCollider2D StandingCol, CrouchCol;

    private float speed;
    private bool IsCrouching = false, canMove = true;
    private Animator playerAnim;
    private Rigidbody2D plRb;

    private void Awake()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        plRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

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
        if (canMove)
        {
            speed = Input.GetAxisRaw("Horizontal");
            playerAnim.SetFloat("Speed", Mathf.Abs(speed));
            plRb.velocity = new Vector2(speed * playerSpeed, plRb.velocity.y);
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
        float jumpForce = Input.GetAxis("Vertical");
        playerAnim.SetFloat("jump", jumpForce);
    }
}