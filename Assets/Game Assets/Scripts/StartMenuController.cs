using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Button btnPlay, btnQuit;
    private void Awake()
    {
        btnPlay.onClick.AddListener(Play);
        btnQuit.onClick.AddListener(Quit);
    }
    private void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Debug.Log("Application is quitting.....");
        Application.Quit();
    }
}
