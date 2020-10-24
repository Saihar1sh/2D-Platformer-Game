using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoorScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 nextTeleportLocation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().TelportTo(nextTeleportLocation);
        }
    }
}
