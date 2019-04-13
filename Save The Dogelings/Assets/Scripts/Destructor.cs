using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{


    GameObject DestructionPoint, Doge;
    [HideInInspector] public bool gameIsOver;

    void Start()
    {
        gameIsOver = false;

        DestructionPoint = GameObject.FindWithTag("Destructor");
        Doge = GameObject.FindWithTag("Doge");




    }

    void Update()
    {



        if (DestructionPoint.transform.position.y > this.transform.position.y)
        {

            if (this.gameObject.tag == ("Doge"))
            {
                gameIsOver = true;

            }
            else
            {
                Destroy(gameObject);

            }

        }
    }
}
