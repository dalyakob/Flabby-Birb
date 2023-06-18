using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LogicManagerScript : MonoBehaviour
{
    public Text HighScore;
    public Text ScoreText;
    public int ScoreCount = 0;
    public GameObject GameOverScreen;
    public GameObject PauseMenu;
    public bool IsGameOver = false;
    public UnityEngine.UI.Slider volumeSlider;
    private void Start()
    {
        Time.timeScale = 1;
        CheckHighScore();
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsGameOver)
        {
            TogglePauseMenu();
        }
    }
    public void BackToMainMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void TogglePauseMenu()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
        else 
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }
    public void IncrementScore( int scoreIncrement)
    {
        if(!IsGameOver)
        {
            ScoreCount += scoreIncrement;
            ScoreText.text = ScoreCount.ToString();
            CheckHighScore();
        }
    } 
    public void GameOver()
    {
        CheckHighScore();
        GameOverScreen.SetActive(true);
        IsGameOver = true;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Playing Again!");
    }
    public void CheckHighScore()
    {
        if(ScoreCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreCount);
        }
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    } 
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
