using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    //LIFE CONTROLLER IS ON DOGE

    public int heartLifes;
    public GameObject heartLife01;
    public GameObject heartLife02;
    public GameObject heartLife03;

    public GameObject scoreController;

    public Sprite heartLifeFull;
    public Sprite heartLifeHalf;
    public Sprite heartLifeEmpty;
    public Sprite darkHeart;

    private int coinCount;
    public bool graceTime = false;

    void Start()
    {
        if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
        {
            heartLifes = 4;

        }
        else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
        {
            heartLifes = 2;

        }
        else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 3)
        {
            heartLifes = 0;

        }


    }

    void Update()
    {
        {
            if (heartLifes == 6)
            {
                heartLife01.GetComponent<Image>().sprite = heartLifeFull;
                heartLife02.GetComponent<Image>().sprite = heartLifeFull;
                heartLife03.GetComponent<Image>().sprite = heartLifeFull;
            }
            else if (heartLifes == 5)
            {
                heartLife01.GetComponent<Image>().sprite = heartLifeFull;
                heartLife02.GetComponent<Image>().sprite = heartLifeFull;
                heartLife03.GetComponent<Image>().sprite = heartLifeHalf;
            }
            else if (heartLifes == 4)
            {
                heartLife01.GetComponent<Image>().sprite = heartLifeFull;
                heartLife02.GetComponent<Image>().sprite = heartLifeFull;
                heartLife03.GetComponent<Image>().sprite = heartLifeEmpty;
            }
            else if (heartLifes == 3)
            {
                heartLife01.GetComponent<Image>().sprite = heartLifeFull;
                heartLife02.GetComponent<Image>().sprite = heartLifeHalf;
                heartLife03.GetComponent<Image>().sprite = heartLifeEmpty;
            }
            else if (heartLifes == 2)
            {
                heartLife01.GetComponent<Image>().sprite = heartLifeFull;
                heartLife02.GetComponent<Image>().sprite = heartLifeEmpty;
                heartLife03.GetComponent<Image>().sprite = heartLifeEmpty;
            }
            else if (heartLifes == 1)
            {
                heartLife01.GetComponent<Image>().sprite = heartLifeHalf;
                heartLife02.GetComponent<Image>().sprite = heartLifeEmpty;
                heartLife03.GetComponent<Image>().sprite = heartLifeEmpty;
            }
            else if (heartLifes == 0)
            {

                heartLife01.GetComponent<Image>().sprite = heartLifeEmpty;
                heartLife02.GetComponent<Image>().sprite = heartLifeEmpty;
                heartLife03.GetComponent<Image>().sprite = heartLifeEmpty;
            }
        }//<- HeartLifes Controller


        coinCount = scoreController.GetComponent<ScoreController>().coinScoreCount;

        if (coinCount > 9)
        {
            if (heartLifes < 6)
            {
                heartLifes++;
                scoreController.GetComponent<ScoreController>().coinScoreCount = 0;
            }
            else if (heartLifes == 6)
            {
                coinCount = 10;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            if (heartLifes >= 0 && graceTime == false && GetComponent<BonusItems>().isFlying == false)

            {
                StartCoroutine(LosingLifesNGraceTime());
            }
        }

    }

    IEnumerator LosingLifesNGraceTime()
    {
        if (heartLifes == 0)
        {
            gameObject.GetComponent<Destructor>().gameIsOver = true;
        }

        if (heartLifes > 0)
        {
            heartLifes--;
            graceTime = true;
            yield return new WaitForSeconds(1.1f);
            graceTime = false;
        }




    }


}
