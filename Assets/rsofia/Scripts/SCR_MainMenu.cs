using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MainMenu : MonoBehaviour {

    public GameObject loginPanel;
    public GameObject newUserPanel;
    public GameObject warningExitPanel;
    public GameObject instructionsPanel;

    private void Start()
    {
        OpenLogin();
    }

    public void OpenLogin()
    {
        CloseAll();
        loginPanel.SetActive(true);
    }

    public void OpenNewUser()
    {
        CloseAll();
        newUserPanel.SetActive(true);
    }

    private void CloseAll()
    {
        loginPanel.SetActive(false);
        newUserPanel.SetActive(false);
        warningExitPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }
    
    public void OpenQuitPanel()
    {
        warningExitPanel.SetActive(true);
    }

    public void CancelQuit()
    {
        warningExitPanel.SetActive(false);
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
