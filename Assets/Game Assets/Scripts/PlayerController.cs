using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private BoxCollider2D boxCol;
    private Rigidbody2D plRb;
    
    private void Awake()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        plRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        boxCol = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        playerAnim.SetFloat("Speed", Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if (speed < 0)
            scale.x = -1f * Mathf.Abs(scale.x);
        else if (speed > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAnim.SetBool("crouching", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            playerAnim.SetBool("crouching", false);
        float jumpForce = Input.GetAxis("Vertical");
        playerAnim.SetFloat("jump", jumpForce);

           
    
    }

}
