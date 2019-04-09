using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text scoreText;
    public float scoreCount;
    public Text highScoreText;
    public Text coinScoreText;

    public float highScoreCount;
    public int coinScoreCount = 0;

    public Transform targetToFollow;
    public float scoreCountPosition;
    public float bonus = 0f;
    // public GameObject sceneController;

    void Start()
    {


        if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
        {
            if (PlayerPrefs.GetFloat("easyHighScorePrefs") > 1000)
            {
                highScoreCount = PlayerPrefs.GetFloat("easyHighScorePrefs");

            }
            else
            {
                highScoreCount = 1000;

            }
        }


        if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
        {
            if (PlayerPrefs.GetFloat("mediumHighScorePrefs") > 1000)
            {
                highScoreCount = PlayerPrefs.GetFloat("mediumHighScorePrefs");

            }
            else
            {
                highScoreCount = 1000;

            }
        }

        if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 3)
        {
            if (PlayerPrefs.GetFloat("hardHighScorePrefs") > 1000)
            {
                highScoreCount = PlayerPrefs.GetFloat("hardHighScorePrefs");

            }
            else
            {
                highScoreCount = 1000;

            }
        }

    }



    void Update()
    {
        if (scoreCount >= highScoreCount)
        {
            highScoreText.color = scoreText.color;

        }

        transform.position = new Vector3(transform.position.x, targetToFollow.position.y, transform.position.z);
        scoreCountPosition = this.transform.position.y + 4f;
        scoreCount = scoreCountPosition + bonus + 6;

        ///
        if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
        {
            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                PlayerPrefs.SetFloat("easyHighScorePrefs", highScoreCount);
            }
        }
        else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
        {
            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                PlayerPrefs.SetFloat("mediumHighScorePrefs", highScoreCount);
            }

        }
        else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 3)
        {
            if (scoreCount > highScoreCount)
            {
                highScoreCount = scoreCount;
                PlayerPrefs.SetFloat("hardHighScorePrefs", highScoreCount);
            }

        }
        ///



        if (coinScoreCount < 10)
        {
            coinScoreText.text = "X 0" + coinScoreCount;


        }
        else
        {
            coinScoreText.text = "X " + coinScoreCount;

        }

        //PlayerPrefs.SetInt("coinScorePrefs", coinScoreCount);


        if (PlayerPrefs.GetString("selectedLanguagePrefs") == "english")
        {
            scoreText.text = "S. " + Mathf.Round(scoreCount);
            highScoreText.text = "HS. " + Mathf.Round(highScoreCount);
        }
        else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "portuguese")

        {
            scoreText.text = "P. " + Mathf.Round(scoreCount);
            highScoreText.text = "PM. " + Mathf.Round(highScoreCount);
        }
        else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "spanish")
        {
            scoreText.text = "P. " + Mathf.Round(scoreCount);
            highScoreText.text = "PM. " + Mathf.Round(highScoreCount);
        }



    }
}
