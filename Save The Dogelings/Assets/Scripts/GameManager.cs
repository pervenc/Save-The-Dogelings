using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public Transform PlayerPosition;
    public GameObject GameOverPrefab;

    public AudioSource MusicGame;
    public AudioSource GameOverSound;
    public AudioSource coinSound;
    public AudioSource dogelingBarkSound;
    public AudioSource dogeCry;

    public GameObject Doge;
    public GameObject bonesCanvas;
    public GameObject dogesHeadsCanvas;

    public Text resumeText;
    public Text restartText;
    public Text mainMenuText;
    public Text exitText;
    public Text difficultText;

    //int audioOnOff = 1;

    bool paused = false;
    bool GamesRunning = true;
    //bool gameIsOver = false;

    void Start()
    {

        Time.timeScale = 1;
        paused = false;

        bonesCanvas.GetComponent<Canvas>().enabled = false;

        dogesHeadsCanvas.GetComponent<Canvas>().enabled = false;

        if (PlayerPrefs.GetString("selectedLanguagePrefs") == "english")
        {
            resumeText.text = "Resume";
            restartText.text = "Restart";
            mainMenuText.text = "Main Menu";
            exitText.text = "Exit";
            if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
            {
                difficultText.text = "Easy Mode";

            }
            else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
            {
                difficultText.text = "Normal Mode";

            }
            else
            {
                difficultText.text = "Hard Mode";

            }

        }
        else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "portuguese")

        {
            resumeText.text = "Resumir";
            restartText.text = "Reiniciar";
            mainMenuText.text = "Menu Princ.";
            exitText.text = "Sair";
            if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
            {
                difficultText.text = "Modo Facil";

            }
            else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
            {
                difficultText.text = "Modo Normal";

            }
            else
            {
                difficultText.text = "Modo Dificil";

            }

        }
        else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "spanish")
        {
            resumeText.text = "Reanudar";
            restartText.text = "Reiniciar";
            mainMenuText.text = "Menu Princ.";
            exitText.text = "Salir";
            if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 1)
            {
                difficultText.text = "Modo Facil";

            }
            else if (PlayerPrefs.GetInt("difficultSelectedPrefs") == 2)
            {
                difficultText.text = "Modo Normal";

            }
            else
            {
                difficultText.text = "Modo Dificil";

            }
        }

    }



    void Update()

    {

        if (PlayerPrefs.GetInt("audioOnOffPrefs") == 1)
        {
            MusicGame.volume = 0.8f;
            GameOverSound.volume = 0.8f;
            coinSound.volume = 0.8f;
            dogelingBarkSound.volume = 0.8f;
            dogeCry.volume = 0.8f;



        }
        else if (PlayerPrefs.GetInt("audioOnOffPrefs") == 0)
        {
            MusicGame.volume = 0;
            GameOverSound.volume = 0;
            coinSound.volume = 0;
            dogelingBarkSound.volume = 0;
            dogeCry.volume = 0;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseFunction();

        }
        GameOver();

    }


    void GameOver()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        if (Doge.GetComponent<Destructor>().gameIsOver == true)
        {
            Doge.GetComponent<DogeMovement>().enabled = false;

            if (GamesRunning)
            {


                Instantiate(GameOverPrefab, spawnPosition, Quaternion.identity);
                GameObject.FindWithTag("Finish").transform.parent = this.transform;


                MusicGame.Stop();
                GameOverSound.Play();
                GamesRunning = false;

            }

            // gameIsOver = true;
            StartCoroutine(StopDoge());

        }
    }

    public void PauseFunction()
    {

        paused = !paused;


        if (paused == true)
        {
            Time.timeScale = 0;

            MusicGame.Pause();
            GameOverSound.Pause();



            if (bonesCanvas.GetComponent<Canvas>().enabled == false || dogesHeadsCanvas.GetComponent<Canvas>().enabled == false)
            {
                bonesCanvas.GetComponent<Canvas>().enabled = true;
                dogesHeadsCanvas.GetComponent<Canvas>().enabled = true;

            }

        }
        if (paused == false)
        {

            bonesCanvas.GetComponent<Canvas>().enabled = false;
            dogesHeadsCanvas.GetComponent<Canvas>().enabled = false;

            Time.timeScale = 1;



            if (Doge.GetComponent<DogeMovement>().enabled == false)
            {
                if (!GameOverSound.isPlaying)
                {

                    GameOverSound.Play();
                }
            }
            else
            {

                if (!MusicGame.isPlaying)
                {
                    MusicGame.Play();
                }
            }


        }

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Has quite game.");
    }

    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        paused = false;
        Time.timeScale = 1;

    }
    public void Menu()
    {

        SceneManager.LoadScene("Menu");

    }


    IEnumerator StopDoge()
    {

        yield return new WaitForSeconds(0.2f);
        Doge.GetComponent<Rigidbody2D>().simulated = false;

    }




}
