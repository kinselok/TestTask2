using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Editor
    [SerializeField]
    private GameObject pausePanel;

    [Header ("Buttons")]
    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private Button exitButton;

    [Header("Labels")]
    [SerializeField]
    private TextMeshProUGUI currentLevel;
    #endregion

    public int CurrentLevel
    {
        set
        {
            currentLevel.SetText(value.ToString());
        }
    }

    private void Awake()
    {
        InitializeButtons();
    }


    private void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }


    private void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }


    private void Exit()
    {
        SceneManager.LoadScene(GameScenes.Scenes.MainMenu.ToString());
    }


    private void InitializeButtons()
    {
        pauseButton.onClick.AddListener(Pause);
        exitButton.onClick.AddListener(Exit);
        resumeButton.onClick.AddListener(Resume);
    }
}
