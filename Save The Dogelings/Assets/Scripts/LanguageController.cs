using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LanguageController : MonoBehaviour
{

    public Text newGameText;
    public Text optionsText;
    public Text exitText;


    public Text controlsText;
    public Text difficultText;
    public Text audioOnOffText;
    public Text languageText;
    public Text highScoresText;
    public Text resetHighScoresText;
    public Text backText;

    public Text languageWoodText;
    public Text englishWoodText;
    public Text portugueseWoodText;
    public Text spanishWoodText;
    public Text difficultWoodText;
    public Text easyWoodText;
    public Text mediumWoodText;
    public Text hardWoodText;
    public Text resetHighScoreWoodText;
    public Text yesResetHighScoreWoodText;
    public Text noResetHighScoreWoodText;
    public Text highScoresWoodText;
    public Text easyHighScoreWoodText;
    public Text mediumHighScoreWoodText;
    public Text hardHighScoreWoodText;


    public Text backHighScoresWoodText;
    public Text backDifficultWoodText;
    public Text backLanguageWoodText;
















    void Start()
    {



        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            if (PlayerPrefs.GetString("selectedLanguagePrefs") == "english")
            {
                newGameText.text = "New Game";
                optionsText.text = "Options";
                exitText.text = "Exit";

            }
            else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "portuguese")

            {
                newGameText.text = "Novo Jogo";
                optionsText.text = "Opcoes";
                exitText.text = "Sair";
            }
            else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "spanish")
            {
                newGameText.text = "Nuevo Juego";
                newGameText.resizeTextMaxSize = 22;

                optionsText.text = "opciones ";
                optionsText.resizeTextMaxSize = 24;

                exitText.text = "Salir";
                exitText.resizeTextMaxSize = 26;

            }
        }




    }

    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Options"))
        {
            if (PlayerPrefs.GetString("selectedLanguagePrefs") == "english")
            {
                controlsText.text = "Controls";
                difficultText.text = "Difficult";
                languageText.text = "Language";
                highScoresText.text = "H. Scores";
                resetHighScoresText.text = "Reset H.S.";
                backText.text = "Back";

                languageWoodText.text = "Language";
                englishWoodText.text = "English";
                portugueseWoodText.text = "Portuguese";
                spanishWoodText.text = "Spanish";
                difficultWoodText.text = "Difficult";
                easyWoodText.text = "Easy";
                mediumWoodText.text = "Medium";
                hardWoodText.text = "Hard";
                resetHighScoreWoodText.text = "Reset all the   high Scores?";
                yesResetHighScoreWoodText.text = "Yes";
                noResetHighScoreWoodText.text = "No";
                highScoresWoodText.text = "High Scores";
                easyHighScoreWoodText.text = "Easy......... ";
                mediumHighScoreWoodText.text = "medium....... ";
                hardHighScoreWoodText.text = "Hard......... ";

                backHighScoresWoodText.text = "back";
                backDifficultWoodText.text = "back";
                backLanguageWoodText.text = "back";

                if (PlayerPrefs.GetInt("audioOnOffPrefs") == 0)
                {
                    audioOnOffText.text = ("SOUND'S OFF");
                }
                else if (PlayerPrefs.GetInt("audioOnOffPrefs") == 1)

                {
                    audioOnOffText.text = ("SOUND'S ON");

                }

            }
            else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "portuguese")

            {
                controlsText.text = "Controles";
                difficultText.text = "Dificuldade";
                languageText.text = "Idioma";
                languageText.resizeTextMaxSize = 26;
                highScoresText.text = "Pont. Max.";
                resetHighScoresText.text = "Reset. P.M.";
                backText.text = "Voltar";

                languageWoodText.text = "Idioma";
                englishWoodText.text = "Ingles";
                portugueseWoodText.text = "Portugues";
                spanishWoodText.text = "Espanhol";
                difficultWoodText.text = "Dificuldade";
                easyWoodText.text = "Facil";
                mediumWoodText.text = "Medio";
                hardWoodText.text = "Dificil";
                resetHighScoreWoodText.text = "Resetar todas pontuacoes maximas?";
                resetHighScoreWoodText.resizeTextMaxSize = 24;
                yesResetHighScoreWoodText.text = "Sim";
                noResetHighScoreWoodText.text = "Nao";
                highScoresWoodText.text = "Pontuacoes Maximas";
                easyHighScoreWoodText.text = "facil........ ";
                mediumHighScoreWoodText.text = "medio........ ";
                hardHighScoreWoodText.text = "dificil....... ";

                backHighScoresWoodText.text = "voltar";
                backDifficultWoodText.text = "voltar";
                backLanguageWoodText.text = "voltar";

                if (PlayerPrefs.GetInt("audioOnOffPrefs") == 0)
                {
                    audioOnOffText.text = ("SOM DESLIG.");
                }
                else if (PlayerPrefs.GetInt("audioOnOffPrefs") == 1)

                {
                    audioOnOffText.text = ("SOM LIG.");

                }
            }
            else if (PlayerPrefs.GetString("selectedLanguagePrefs") == "spanish")
            {

                controlsText.text = "Controles";
                difficultText.text = "Dificultad";
                languageText.text = "Idioma";
                languageText.resizeTextMaxSize = 26;
                highScoresText.text = "Punt. Max.";
                resetHighScoresText.text = "Reset. P.M.";
                backText.text = "Atras";


                languageWoodText.text = "Idioma";
                englishWoodText.text = "Ingles";
                portugueseWoodText.text = "Portugues";
                spanishWoodText.text = "Espanol";
                difficultWoodText.text = "Dificultad";
                easyWoodText.text = "Facil";
                mediumWoodText.text = "Medio";
                hardWoodText.text = "Dificil";
                resetHighScoreWoodText.text = "Restablecer puntajes maximos?";
                yesResetHighScoreWoodText.text = "Si";
                noResetHighScoreWoodText.text = "No";
                highScoresWoodText.text = "puntajes maximos";
                easyHighScoreWoodText.text = "facil........ ";
                mediumHighScoreWoodText.text = "medio........ ";
                hardHighScoreWoodText.text = "dificil....... ";

                backHighScoresWoodText.text = "atras";
                backDifficultWoodText.text = "atras";
                backLanguageWoodText.text = "atras";

                if (PlayerPrefs.GetInt("audioOnOffPrefs") == 0)
                {
                    audioOnOffText.text = ("Sonido Ap.");
                }
                else if (PlayerPrefs.GetInt("audioOnOffPrefs") == 1)

                {
                    audioOnOffText.text = ("Sonido Enc.");

                }
            }
        }

    }
}
