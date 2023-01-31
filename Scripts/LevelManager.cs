using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject levelPanal;
    [SerializeField] GameObject startPanal;
    [SerializeField] GameObject musicPanal;

    private int levelsUnlocked;
    public Button[] buttons;


    void Start()
    {
        levelPanal.SetActive(false);
        startPanal.SetActive(true);


        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);
        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }


    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }


    public void StartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }


    public void BackButton()
    {
        levelPanal.SetActive(false);
        startPanal.SetActive(true);
    }

    public void LevelMenuActive()
    {
        levelPanal.SetActive(true);
        startPanal.SetActive(false);
    }

    public void MenuButton()
    {
        musicPanal.SetActive(false);
        startPanal.SetActive(true);
    }

    public void SoundButton()
    {
        startPanal.SetActive(false);
        musicPanal.SetActive(true);
    }
}
