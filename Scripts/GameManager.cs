using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform damagePopUp;

    public TMP_Text scoreText;
    public int score;
    public int targetScore;

    public GameObject levelCompletePanal, gameOverPanal, gamePausePanal, joystickPanal;

    private void Awake()
    {
        instance = this;
    }


    public void UpdateScore()
    {
        score += 10;
        scoreText.text = score.ToString();
        AudioManager.instance.PlaySFX(3);

        
        if (score >= targetScore)
        {
            levelCompletePanal.SetActive(true);
            joystickPanal.SetActive(false);


            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
            {
                PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
            }
            Time.timeScale = 0;
        }
    }





    // Buttons

    public void ResumButton()
    {
        gamePausePanal.SetActive(false);
        joystickPanal.SetActive(true);
        Time.timeScale = 1;
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }




    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }


    public void GameQuit()
    {
        Application.Quit();
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }


    public void PauseButton()
    {
        gamePausePanal.SetActive(true);
        joystickPanal.SetActive(false);
        Time.timeScale = 0;
    }

}
