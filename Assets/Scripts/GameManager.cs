using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] TextMeshProUGUI milkText;
    [SerializeField] TextMeshProUGUI eggsText;

    int milkCount;
    public int MilkCount // ENCAPSULATION
    { 
        get { return milkCount; }
        set
        {
            if (value < 0)
                milkCount = 0;
            else
                milkCount = value;

            DisplayScore();
        } 
    }

    int eggsCount;
    public int EggsCount
    {
        get { return eggsCount; }
        set
        {
            if (value < 0)
                eggsCount = 0;
            else
                eggsCount = value;

            DisplayScore();
        }
    }

    private void Awake()
    {

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (MainManager.Instance != null)
        {
            playerController.SetCharacter(MainManager.Instance.playerInfo.playerCharacter);

            DisplayScore();
        }
        else
        {
            Application.Quit();
        }

    }

    void DisplayScore() // ABSTRACTION
    {
        milkText.text = MainManager.Instance.languageText.MILK_SCORE.Replace("{0}", milkCount.ToString());
        eggsText.text = MainManager.Instance.languageText.EGGS_SCORE.Replace("{0}", eggsCount.ToString());
    }
}

