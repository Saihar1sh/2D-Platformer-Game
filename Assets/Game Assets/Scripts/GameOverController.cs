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
    private void Start()
    {
        gameObject.SetActive(false);

    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
