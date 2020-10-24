using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnPlay, btnQuit, btnLevelSelect, btnCloseLevelMenu, btnContinue, btnNewGame, btnReturnToMenu;
    [SerializeField]
    private GameObject MainMenu, LevelSelect, PlayMenu;

    private LevelManager manager;

    private void Awake()
    {
        btnPlay.onClick.AddListener(Play);
        btnQuit.onClick.AddListener(Quit);
        btnLevelSelect.onClick.AddListener(LevelSelectMenu);
        btnReturnToMenu.onClick.AddListener(ReturnToMainMenu);
        btnCloseLevelMenu.onClick.AddListener(CloseLevelMenu);
        btnContinue.onClick.AddListener(ContinueGame);
        btnNewGame.onClick.AddListener(NewGame);
    }
    private void Start()
    {
        LevelSelect.SetActive(false);
        PlayMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    private void Play()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);
    }
    private void ReturnToMainMenu()
    {
        PlayMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    private void ContinueGame()
    {
        //going to use playerprefs and checkpoints
    }
    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    private void LevelSelectMenu()
    {
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
    }
    private void CloseLevelMenu()
    {
        LevelSelect.SetActive(false);
        MainMenu.SetActive(true);
    }
    private void Quit()
    {
        Debug.Log("Application is quitting.....");
        Application.Quit();
    }
}
