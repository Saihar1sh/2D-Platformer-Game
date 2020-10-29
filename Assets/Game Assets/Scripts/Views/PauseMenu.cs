using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button btnRestart, btnMainMenu, btnMute;
    [SerializeField]
    private TextMeshProUGUI currentLvlText;

    private bool menuEnabled = false, isMute = false;
    private void Awake()
    {
        btnRestart.onClick.AddListener(ReloadLevel);
        btnMainMenu.onClick.AddListener(LoadMenu);
        btnMute.onClick.AddListener(MuteAudio);
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void MenuEnable()
    {
        menuEnabled = !menuEnabled;
        SoundManager.Instance.Play(Sounds.buttonPause);
        currentLvlText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        gameObject.SetActive(menuEnabled);
        if (menuEnabled)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
    private void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.buttonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadMenu()
    {
        SoundManager.Instance.Play(Sounds.buttonBack);
        SceneManager.LoadScene(0);
    }
    private void MuteAudio()
    {
        isMute = !isMute;
        SoundManager.Instance.Mute(isMute);
    }
    //public void load()
    //{
    //    LevelManager.Instance.LoadSaveGame();
    //}

}
