using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal // INHERITANCE
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void Action() // POLYMORPHISM
    {
        base.Action();
        gameManager.MilkCount++;
    }
}
