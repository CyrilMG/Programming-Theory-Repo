﻿using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        if(MainManager.Instance != null)
        {

        }
        else
        {
            Application.Quit();
        }

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.SetCharacter(MainManager.Instance.playerInfo.playerCharacter);
    }

}

