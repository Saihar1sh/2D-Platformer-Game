using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public string MainMenu;
    public string[] Levels;

    public Vector2 lastCheckptPos;

    private PlayerController playerScript;

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
   private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //ResetLevelStatus();
          SetLevelStatus(MainMenu, LevelStatus.Unlocked);
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);
        Debug.Log("Current scene" + currentScene.name);
        int currentSceneIndex =  Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < Levels.Length)
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
    }
    public void ResetLevelStatus()
    {
        //for reseting levels lock state
        SetLevelStatus("Lvl1", LevelStatus.Unlocked);
        for (int i = 1; i < 4; i++)
            SetLevelStatus(Levels[i], LevelStatus.Locked);
        Debug.Log("Levels has been reset");
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level,0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
    
    public void PlayerLastCheckpt(Vector2 checkPoint)
    {
        lastCheckptPos = checkPoint;
        Debug.Log("Last checkpt set");

    }
    //public void LoadSaveGame()
    //{
    //    if (FindObjectOfType<PlayerController>() != null)
    //    {
    //        PlayerData playerData = SaveSystem.LoadGame();
    //        SceneManager.LoadScene(playerData.level);
    //        playerScript.LoadGame();
    //    }
    //    else
    //    {
    //        Debug.Log("Player controller is not found");
            
    //    }            
    //}
}
