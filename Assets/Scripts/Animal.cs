using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed;

    private string name;
    public string Name 
    { 
        get { return name; } 
        set
        {
            if(value.Length <= 10)
            {
                name = value;
            }
            else
            {
                Debug.LogError("Name is too long");
            }
        } 
    }

    public void Update()
    {
        Move();
    }

    protected virtual void Move()
    {

    }

    public virtual void Action()
    {

    }
}
