using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void Action()
    {
        base.Action();
        gameManager.EggsCount++;   
    }
}
