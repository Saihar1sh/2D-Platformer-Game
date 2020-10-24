using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool idiotEnemy = false;
    
    private bool isGrounded, frontDetected;
    private int facingDirection = 1;
    [SerializeField]
    private float enemySpeed, groundCheckDist, frontCheckDist;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform groundCheck, frontCheck;
    [SerializeField]
    private PlayerHeartsController heartsController;


    private void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = facingDirection * Mathf.Abs(scale.x);
        transform.localScale = scale;
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDist, whatIsGround);
        frontDetected = Physics2D.Raycast(frontCheck.position, transform.right, frontCheckDist, whatIsGround);

    }
    private void FixedUpdate()
    {
        if (!idiotEnemy)
        {
            if (!isGrounded || frontDetected)
            {
                facingDirection *= -1;
            }
            else
            {
                Vector3 position = transform.position;
                position.x += facingDirection * enemySpeed * Time.deltaTime;
                transform.position = position;

            }
        }
        else
        {
            Vector3 position = transform.position;
            position.x += facingDirection * enemySpeed * Time.deltaTime;
            transform.position = position;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDist));
        Gizmos.DrawLine(frontCheck.position, new Vector2(frontCheck.position.x + frontCheckDist, frontCheck.position.y));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.DecreaseLives();
        }
    }
}
