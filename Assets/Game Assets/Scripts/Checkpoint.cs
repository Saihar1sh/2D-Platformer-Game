using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector2 previousCheckpoint;
    [SerializeField]
    private GameObject checkpointOn, checkpointOff;

    private void Start()
    {
        checkpointOn.SetActive(false);
        checkpointOff.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            previousCheckpoint = collision.gameObject.transform.position;
            checkpointOn.SetActive(true);
            LevelManager.Instance.PlayerLastCheckpt(previousCheckpoint);

        }

    }

}
