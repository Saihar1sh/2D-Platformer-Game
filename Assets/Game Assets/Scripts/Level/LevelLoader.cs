using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }
    private void click()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        Debug.Log("level name: " + LevelName + " status: " + levelStatus);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.Play(Sounds.buttonInvalid);
                Debug.Log("Can't play this yet. You have to complete it first.");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.buttonStart);
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.buttonStart);
                SceneManager.LoadScene(LevelName);
                break;

        }
    }

}
