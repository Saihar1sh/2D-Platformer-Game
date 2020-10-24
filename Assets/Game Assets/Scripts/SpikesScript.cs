using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Ow!..Ow!..So many spikes");
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.DecreaseLives();
        }

    }
}
