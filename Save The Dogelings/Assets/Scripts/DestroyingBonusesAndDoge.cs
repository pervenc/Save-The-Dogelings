using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyingBonusesAndDoge : MonoBehaviour
{
    public GameObject Doge;
    public Rigidbody2D rb;
    public GameObject platformGen;


    private void Start()
    {
        Doge = GameObject.FindWithTag("Doge");

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FlyFlower"))
        {
            platformGen.GetComponent<PlatformGen>().respawnBonuses = false;

            StartCoroutine(WaitToRespawnBonuses());


        }
        if (other.CompareTag("Doge") && this.gameObject.tag != "Spikes")
        {
            if (this.gameObject.tag == ("FlyFlower"))
            {
                StartCoroutine(WaitABitToDestroy());
            }
            else
            {
                Destroy(gameObject);

            }
        }
        else if (other.CompareTag("Doge"))
        {
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
        if (other.CompareTag("Spikes"))
        {
            gameObject.GetComponent<Destructor>().gameIsOver = true;

        }
    }


    IEnumerator WaitToRespawnBonuses()
    {

        yield return new WaitForSeconds(4f);
        platformGen.GetComponent<PlatformGen>().respawnBonuses = true;


    }
    IEnumerator WaitABitToDestroy()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);


    }

}
