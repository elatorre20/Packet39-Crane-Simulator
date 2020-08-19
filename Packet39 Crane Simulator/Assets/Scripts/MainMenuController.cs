using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialMenu;
    public GameObject settingsMenu;

    public void startGame()
    {
        SceneManager.LoadScene("CraneTraining", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showTutorial()
    {
        mainMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
    }

    public void showMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        tutorialMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
    }

    public void showSettingsMenu()
    {
        mainMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }
}
