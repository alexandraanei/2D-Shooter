using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public GameObject MainMenu;
    public GameObject deathScreen;
    public Button playButton;
    public Button optionsButton;
    public Button goBackButton;
    public Button highscoresButton;
    public GameObject leaderboard;
    public Text[] highscores;
    public Text winMessage;
    public Text loseMessage;
    public Text volumeMessage;
    public InputField highscoreName;
    public Text HSMessage;
    public Button saveButton;
    public Button exitButton;
    public Slider volumeSlider;
    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            // set the volume to saved volume
            music.volume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = music.volume;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            PressPlay();
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void CheckIfHighscore()
    {
        if (HighscoreScript.ReturnHighscores() == null || HighscoreScript.ReturnHighscores().highscores.Length < 5 || score >= HighscoreScript.ReturnHighscores().highscores[4].score)
        {
            saveButton.gameObject.SetActive(true);
            highscoreName.gameObject.SetActive(true);
            HSMessage.gameObject.SetActive(true);
        }
    }

    public void AddScore(int scorePoints)
    {
        score += scorePoints;
    }

    public void PressPlay(){

        Time.timeScale = 1;
        MainMenu.SetActive(false);
    }

    //Se afiseaza ce corespunde mortii playerului
    public void PlayerDied(){

        deathScreen.SetActive(true);
        Time.timeScale = 0;
        CheckIfHighscore();
    }

    public void BossDied()
    {
        
        deathScreen.SetActive(true);
        Time.timeScale = 0;
        CheckIfHighscore();
    }

    public void SaveHighscore()
    {
        if (highscoreName.text != "" && highscoreName.text != null)
        {
            HighscoreScript.WriteHSFile(highscoreName.text, GameObject.Find("GameManager").GetComponent<GameManagerScript>().score);
            saveButton.gameObject.SetActive(false);
        }
    }

    public void OnClickOptions()
    {
        playButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        highscoresButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        goBackButton.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        volumeMessage.gameObject.SetActive(true);
    }

    public void OnClickGoBack()
    {
        playButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        highscoresButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        goBackButton.gameObject.SetActive(false);
        leaderboard.gameObject.SetActive(false);
        volumeSlider.gameObject.SetActive(false);
        volumeMessage.gameObject.SetActive(false);
    }

    public void OnClickHighscores()
    {
        playButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        highscoresButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        goBackButton.gameObject.SetActive(true);
        leaderboard.gameObject.SetActive(true);
        highscores = leaderboard.GetComponentsInChildren<Text>();
        GetHighscores();
    }

    public void GetHighscores()
    {
        for(int i = 0; i < Mathf.Min(5, HighscoreScript.ReturnHighscores().highscores.Length); i++)
        {
            highscores[i].text = (i + 1).ToString() + ". " + HighscoreScript.ReturnHighscores().highscores[i].name + " - " + HighscoreScript.ReturnHighscores().highscores[i].score.ToString();
        }
    }

    public void ChangeVolume()
    {
        music.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", music.volume);
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PressExit()
    {
        Application.Quit();
    }
}

