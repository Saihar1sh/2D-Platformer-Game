using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.KillPlayer();
        }
    }
}
