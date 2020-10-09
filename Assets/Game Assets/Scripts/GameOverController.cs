using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button btnRestart;

    private void Awake()
    {
        btnRestart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
        Debug.Log("Gameover ");
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
