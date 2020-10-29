using System.Collections;
using UnityEngine;

public class LevelOverScript : MonoBehaviour
{
    private int totalKeys, keysLeft;
    [SerializeField]
    private GameObject levelOverScreen;
    [SerializeField]
    private KeyScore KeyScore;
    [SerializeField]
    private GameObject confettiParticles;

    private void Start()
    {
        confettiParticles.SetActive(false);
       totalKeys = FindObjectsOfType<KeyController>().Length;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed");
            StartCoroutine(SecsGapToLvlComplete(2.0f));
            confettiParticles.SetActive(true);
            LevelManager.Instance.PlayerLastCheckpt(new Vector2(0, 0));
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
    private IEnumerator SecsGapToLvlComplete(float secs)
    {
        Debug.Log(secs + " Secs timer start");
        yield return new WaitForSeconds(secs);
        Debug.Log(secs + " Secs completed");
        levelOverScreen.SetActive(true);
        keysLeft = FindObjectsOfType<KeyController>().Length;
        KeyScore.KeysScoreUI(keysLeft, totalKeys);

        Time.timeScale = 0f;

    }

}
