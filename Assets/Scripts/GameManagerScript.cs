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

    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            PressPlay();
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
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
    }

    public void HideButtons()
    {
        playButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        goBackButton.gameObject.SetActive(true);
    }

    public void ShowButtons()
    {
        playButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        goBackButton.gameObject.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

