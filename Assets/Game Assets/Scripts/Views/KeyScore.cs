using UnityEngine;
using TMPro;

public class KeyScore : MonoBehaviour
{
    private TextMeshProUGUI keyScore;

    private void Awake()
    {
        keyScore = GetComponent<TextMeshProUGUI>();
    }
    public void KeysScoreUI(int keysLeft,int totalKeys)
    {
        int keysCollected = totalKeys - keysLeft;
        keyScore.text = "X " + keysCollected + "/" + totalKeys;
    }
}
