using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.PickupKey();
            Destroy(gameObject);
        }
        
    }
}
