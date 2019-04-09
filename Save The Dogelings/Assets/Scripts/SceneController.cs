using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public AudioSource MusicGame;
    public Text easyHighScoreTextValue;
    public Text mediumHighScoreTextValue;
    public Text hardHighScoreTextValue;

    public GameObject resetHSConfirmCanvas;
    public GameObject highSocoresCanvas;
    public GameObject languageCanvas;
    public GameObject difficultCanvas;

    public GameObject easyToggle;
    public GameObject mediumToggle;
    public GameObject hardToggle;

    public GameObject englishToggle;
    public GameObject portugueseToggle;
    public GameObject spanishToggle;

    public int difficultSelected;








    public float easyHighScoreValue;
    public float mediumHighScoreValue;
    public float hardHighScoreValue;

    public string selectedLanguage;


    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Options"))
        {


            easyHighScoreValue = PlayerPrefs.GetFloat("easyHighScorePrefs");
            mediumHighScoreValue = PlayerPrefs.GetFloat("mediumHighScorePrefs");
            hardHighScoreValue = PlayerPrefs.GetFloat("hardHighScorePrefs");



            if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
            {
                easyToggle.GetComponent<Toggle>().isOn = true;
            }
            else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
            {
                mediumToggle.GetComponent<Toggle>().isOn = true;

            }
            else
            {
                hardToggle.GetComponent<Toggle>().isOn = true;

            }


            if (PlayerPrefs.GetString("selectedLanguagePrefs") == "english")
            {
                englishToggle.GetComponent<Toggle>().isOn = true;
            }
            else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "portuguese")
            {
                portugueseToggle.GetComponent<Toggle>().isOn = true;

            }
            else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "spanish")
            {
                spanishToggle.GetComponent<Toggle>().isOn = true;

            }



        }
    }
    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Options"))
        {






            if (easyToggle.GetComponent<Toggle>().isOn)
            {
                difficultSelected = 1;
            }
            else if (mediumToggle.GetComponent<Toggle>().isOn)
            {
                difficultSelected = 2;
            }
            else
            {
                difficultSelected = 3;
            }

            PlayerPrefs.SetInt("difficultSelectedPrefs", difficultSelected);



            if (englishToggle.GetComponent<Toggle>().isOn)
            {
                selectedLanguage = "english";
            }
            else if (portugueseToggle.GetComponent<Toggle>().isOn)
            {
                selectedLanguage = "portuguese";
            }
            else if (spanishToggle.GetComponent<Toggle>().isOn)
            {
                selectedLanguage = "spanish";
            }






            PlayerPrefs.SetString("selectedLanguagePrefs", selectedLanguage);




        }




        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Options"))
        {
            if (easyHighScoreValue > 1000)
            {
                easyHighScoreTextValue.text = ("" + Mathf.Round(easyHighScoreValue));
            }
            else
            {
                easyHighScoreTextValue.text = ("" + 1000);
            }

            //---

            if (mediumHighScoreValue > 1000)
            {
                mediumHighScoreTextValue.text = ("" + Mathf.Round( mediumHighScoreValue));

            }
            else
            {
                mediumHighScoreTextValue.text = ("" + 1000);

            }

            //---

            if (hardHighScoreValue > 1000)
            {
                hardHighScoreTextValue.text = ("" + Mathf.Round(hardHighScoreValue));
            }
            else
            {
                hardHighScoreTextValue.text = ("" + 1000);

            }


        }




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (resetHSConfirmCanvas.GetComponent<Canvas>().enabled == true)

            {
                resetHSConfirmCanvas.GetComponent<Canvas>().enabled = false;

            }
            else
            {
                SceneManager.LoadScene("Menu");

            }

        }

        if (PlayerPrefs.GetInt("audioOnOffPrefs") == 1)
        {
            MusicGame.volume = 0.5f;

            // MusicGame.SetActive(true);



        }
        else if (PlayerPrefs.GetInt("audioOnOffPrefs") == 0)
        {
            MusicGame.volume = 0;
            // MusicGame.SetActive(false);


        }




    }

    //END OF UPDATE FUNCTION ============================================

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Has quite game.");
    }

    public void Startgame()
    {

        SceneManager.LoadScene("Game");
    }

    public void Options()
    {

        SceneManager.LoadScene("Options");
    }
    public void Menu()
    {

        SceneManager.LoadScene("Menu");

    }

    public void HighSocores()
    {
        highSocoresCanvas.GetComponent<Canvas>().enabled = true;


    }

    public void Languages()
    {
        languageCanvas.GetComponent<Canvas>().enabled = true;


    }
    public void Difficult()
    {
        difficultCanvas.GetComponent<Canvas>().enabled = true;


    }

    public void CloseHighScores()
    {
        highSocoresCanvas.GetComponent<Canvas>().enabled = false;


    }
    public void CloseAllCanvas()
    {
        highSocoresCanvas.GetComponent<Canvas>().enabled = false;
        languageCanvas.GetComponent<Canvas>().enabled = false;
        difficultCanvas.GetComponent<Canvas>().enabled = false;


    }

    public void AudioOnOff()
    {
        // PlayerPrefs.SetInt("audioOnOffPrefs", 1);

        if (PlayerPrefs.GetInt("audioOnOffPrefs") == 0)
        {
            PlayerPrefs.SetInt("audioOnOffPrefs", 1);
        }
        else if (PlayerPrefs.GetInt("audioOnOffPrefs") == 1)

        {
            PlayerPrefs.SetInt("audioOnOffPrefs", 0);

        }





    }


    public void ZeroHS()
    {

        resetHSConfirmCanvas.GetComponent<Canvas>().enabled = true;

    }

    public void ZeroHSYes()
    {
        PlayerPrefs.SetFloat("highScorePrefs", 0);
        resetHSConfirmCanvas.GetComponent<Canvas>().enabled = false;

    }
    public void ZeroHSNo()
    {
        resetHSConfirmCanvas.GetComponent<Canvas>().enabled = false;

    }

}
