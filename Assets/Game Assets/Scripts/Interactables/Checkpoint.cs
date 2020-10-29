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
            SoundManager.Instance.Play(Sounds.checkPoint);
            GameObject player = collision.gameObject;
            previousCheckpoint = player.transform.position;
            checkpointOn.SetActive(true);
            LevelManager.Instance.PlayerLastCheckpt(previousCheckpoint);
            //player.GetComponent<PlayerController>().SaveGame();
        }

    }

}
