using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverScript : MonoBehaviour
{
    public GameObject levelOverScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed");
            LevelManager.Instance.MarkCurrentLevelComplete();
            levelOverScreen.SetActive(true);
        }
    }
}
