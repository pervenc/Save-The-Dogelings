using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]



public class BonusItems : MonoBehaviour
{

    Rigidbody2D rb;

    public GameObject scoreController;
    public GameObject doge;

    public AudioSource dogelingBark;
    public AudioSource CoinSound;
    public AudioSource flyLeafSound;
    public AudioSource crunchSound;
    public AudioSource dogeCry;


    public Text scoreText;
    public Text coinText;



    public Color bonusColor;
    public Color blackColor;
    public Color dogeRegularColor;
    public Color dogeDamagingColor;
    public Color dogeDarkColor;


    public Renderer rend;

    public bool isFlying=false;

  




    void Start()
    {
        rend = GetComponent<Renderer>();


        scoreController = GameObject.FindWithTag("ScoreController");
        rb = GetComponent<Rigidbody2D>();


    }



    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dogeling"))
        {
            StartCoroutine(ChanginScoreColor());

            scoreController.GetComponent<ScoreController>().bonus = 50 + scoreController.GetComponent<ScoreController>().bonus;
            // Instantiate(scoreEffect, scorePositionParticles.transform.position, Quaternion.identity);

            dogelingBark.Play();

        }
        else if (other.CompareTag("Coin"))
        {
            StartCoroutine(ChanginCoinTextColor());

            scoreController.GetComponent<ScoreController>().coinScoreCount++;
            //Instantiate(scoreEffect, scorePositionParticles.transform.position, scorePositionParticles.transform.rotation);    

            CoinSound.Play();

        }
        else if (other.CompareTag("FlyFlower"))
        {
            flyLeafSound.Play();


            StartCoroutine(FlyFlowerTransition());


        }
        else if (other.CompareTag("BigMeat"))
        {
            StartCoroutine(ChanginScoreColor());

            scoreController.GetComponent<ScoreController>().bonus = 25 + scoreController.GetComponent<ScoreController>().bonus;
            crunchSound.volume = 0.6f;
            crunchSound.Play();
        }
        else if (other.CompareTag("Meat"))
        {
            StartCoroutine(ChanginScoreColor());

            scoreController.GetComponent<ScoreController>().bonus = 15 + scoreController.GetComponent<ScoreController>().bonus;
            crunchSound.volume = 0.6f;

            crunchSound.Play();
        }
        else if (other.CompareTag("Spikes"))
        {

            if (doge.GetComponent<LifeController>().heartLifes == 0)
            {

                doge.GetComponent<SpriteRenderer>().sprite = null;
                doge.GetComponent<Rigidbody2D>().simulated = false;


                doge.GetComponent<DogeMovement>().enabled = false;
               // rb.velocity = new Vector3(0, -30, 0);
                //enabled = false;
            }
            else
            {

                StartCoroutine(ChanginDogeColor());
                dogeCry.volume = 0.6f;
                dogeCry.Play();
            }
        


        }

    }

    IEnumerator ChanginDogeColor()
    {
        for (int i = 0; i < 5; i++)
        {
            rend.material.color = dogeDamagingColor;
            yield return new WaitForSeconds(0.08f);
            rend.material.color = dogeRegularColor;
            yield return new WaitForSeconds(0.08f);
            rend.material.color = dogeDarkColor;
        }
        
       
        yield return new WaitForSeconds(0.04f);
        rend.material.color = dogeRegularColor;

    }
    IEnumerator ChanginScoreColor()
    {
        scoreText.color = bonusColor;
        yield return new WaitForSeconds(0.06f);
        scoreText.color = blackColor;
        yield return new WaitForSeconds(0.06f);
        scoreText.color = bonusColor;
        yield return new WaitForSeconds(0.06f);
        scoreText.color = blackColor;
    }

    IEnumerator ChanginCoinTextColor()
    {
        coinText.color = bonusColor;
        yield return new WaitForSeconds(0.06f);
        coinText.color = blackColor;
        yield return new WaitForSeconds(0.06f);
        coinText.color = bonusColor;
        yield return new WaitForSeconds(0.06f);
        coinText.color = blackColor;
    }


    IEnumerator FlyFlowerTransition()
    {
        isFlying = true;


        GetComponent<LifeController>().graceTime = true;

        GetComponent<BoxCollider2D>().isTrigger = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector3(0, 0, 0);

        rb.AddForce(Vector3.up * 1.8f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(3f);
        rb.gravityScale = 0.2f;
        yield return new WaitForSeconds(0.4f);
        rb.gravityScale = 0.4f;
        yield return new WaitForSeconds(0.4f);
        rb.gravityScale = 0.6f;
        yield return new WaitForSeconds(0.4f);
        rb.gravityScale = 0.8f;
        yield return new WaitForSeconds(0.3f);


        GetComponent<BoxCollider2D>().isTrigger = false;
        rb.gravityScale = 1f;

        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(Vector3.up * 0, ForceMode2D.Impulse);


        GetComponent<LifeController>().graceTime = false;
        isFlying = false;




    }

}
