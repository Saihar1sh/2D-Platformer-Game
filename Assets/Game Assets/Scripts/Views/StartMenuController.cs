using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnQuit, btnLevelSelect, btnCloseLevelMenu, btnContinue;
    [SerializeField]
    private GameObject MainMenu, LevelSelect;

    private void Awake()
    {
        btnQuit.onClick.AddListener(Quit);
        btnLevelSelect.onClick.AddListener(LevelSelectMenu);
        btnCloseLevelMenu.onClick.AddListener(CloseLevelMenu);
        btnContinue.onClick.AddListener(ContinueGame);
    }
    private void Start()
    {
        LevelSelect.SetActive(false);
        MainMenu.SetActive(true);
    }
    private void ContinueGame()
    {
        //going to use playerprefs and checkpoints
        //LevelManager.Instance.LoadSaveGame();
    }
    private void LevelSelectMenu()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
    }
    private void CloseLevelMenu()
    {
        SoundManager.Instance.Play(Sounds.buttonBack);
        LevelSelect.SetActive(false);
        MainMenu.SetActive(true);
    }
    private void Quit()
    {
        SoundManager.Instance.Play(Sounds.buttonBack);
        Debug.Log("Application is quitting.....");
        Application.Quit();
    }
}
