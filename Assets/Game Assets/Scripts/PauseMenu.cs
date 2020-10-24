using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button btnRestart, btnMainMenu;

    private bool menuEnabled = false;
    private void Awake()
    {
        btnRestart.onClick.AddListener(ReloadLevel);
        btnMainMenu.onClick.AddListener(LoadMenu);
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
        gameObject.SetActive(menuEnabled);
        if (menuEnabled)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
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
