using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Manager manager;
    public GameObject NewGameButton;
    public GameObject ContinueButton;
    public GameObject ClearDataButton;
    private bool canContinue;

    void Start()
    {
        manager = FindObjectOfType<Manager>();
        Init();
    }

    public void Init()
    {
        CheckData();

        if (canContinue)
        {
            NewGameButton.SetActive(false);
            ContinueButton.SetActive(true);
            ClearDataButton.SetActive(true);
        }
        else
        {
            NewGameButton.SetActive(true);
            ContinueButton.SetActive(false);
            ClearDataButton.SetActive(false);
        }
    }
    public void CheckData()
    {
        int goldCheck = PlayerPrefs.GetInt("Gold", 0);
        int lumberCheck = PlayerPrefs.GetInt("Lumber", 0);
        int gemCheck = PlayerPrefs.GetInt("Gems", 0);

        if (goldCheck >= 1 || lumberCheck >= 1 || gemCheck >= 1)
        {
            manager.Gold = goldCheck;
            manager.Lumber = lumberCheck;
            manager.Gems = gemCheck;
            canContinue = true;
        }
    }

    public void NewGame()
    {
        manager.Gold = 0;
        manager.Lumber = 0;
        manager.Gems = 0;
        manager.TurnOnUI();
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        manager.TurnOnUI();
        SceneManager.LoadScene(1);
    }

    public void ClearData()
    {
        manager.Gold = 0;
        manager.Lumber = 0;
        manager.Gems = 0;
        manager.SaveData();
    }
}