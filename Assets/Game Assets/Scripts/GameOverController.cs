using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button btnRestart, btnMenu;

    private void Awake()
    {
        btnRestart.onClick.AddListener(ReloadLevel);
        btnMenu.onClick.AddListener(LoadMenu);
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

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
