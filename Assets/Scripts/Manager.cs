using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [Header("Resources")]
    public int Gold;
    public int Lumber;
    public int Gems;
    [Header("Resource objects")]
    public TMP_Text goldText;
    public TMP_Text lumberText;
    public TMP_Text gemText;
    [Header("Units and buildings")]
    public GameObject[] peasants;
    [Header("UI")]
    public GameObject mainUI;
    public GameObject pauseMenu;

    private static Manager _instance;
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void FetchVars()
    {
        goldText = FindObjectOfType<Gold>().GetComponent<TMP_Text>();
        lumberText = FindObjectOfType<Lumber>().GetComponent<TMP_Text>();
        gemText = FindObjectOfType<Gems>().GetComponent<TMP_Text>();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Gold", Gold);
        PlayerPrefs.SetInt("Lumber", Lumber);
        PlayerPrefs.SetInt("Gems", Gems);
    }

    public void UpdateHotBar()
    {
        goldText.text = "Gold: " + Gold.ToString();
        lumberText.text = "Lumber: " + Lumber.ToString();
        gemText.text = "Gems: " + Gems.ToString();
    }

    public void TurnOnUI()
    {
        mainUI.SetActive(true);
        UpdateHotBar();
    }

    public void OpenPauseMenu()
    {
        //Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        //Time.timeScale = 1f; 
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        SaveData();
        CloseMenu();
        SceneManager.LoadScene(0);
    }
}
