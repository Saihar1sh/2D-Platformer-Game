using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartsController : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;

    private Image heartImage1, heartImage2, heartImage3;

    private void Awake()
    {
        heartImage1 =  heart1.GetComponent<Image>();
        heartImage2 = heart2.GetComponent<Image>();
        heartImage3 = heart3.GetComponent<Image>();
    }
    public void heartlost(int lives)
    {
        switch (lives)
        {
            case 2:
                heartImage1.enabled = false;
                break;
            case 1:
                heartImage2.enabled = false;
                break;
            case 0:
                heartImage3.enabled = false;
                break;
        }
    }
}
