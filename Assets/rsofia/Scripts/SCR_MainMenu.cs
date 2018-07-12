using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MainMenu : MonoBehaviour {

    public GameObject loginPanel;
    public GameObject newUserPanel;
    public GameObject instructionsPanel;
    public SCR_QuitGame quitGame;

    private void Start()
    {
        if (quitGame == null)
            FindObjectOfType<SCR_QuitGame>();
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
        quitGame.warningExitPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }    
  

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void OpenGameSelection()
    {
        FindObjectOfType<SCR_Loading>().LoadScene("GameSelection");
    }

    public void OpenLevelSelection()
    {
        Debug.Log("Abriendo seleccion de niveles");
        FindObjectOfType<SCR_Loading>().LoadScene("LevelSelection");
    }

}
