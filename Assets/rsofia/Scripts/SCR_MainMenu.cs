using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MainMenu : MonoBehaviour {

    public GameObject loginPanel;
    public GameObject newUserPanel;
    public GameObject instructionsPanel;
    public GameObject informationPanel;
    public GameObject creditosPanel;
    public SCR_QuitGame quitGame;
    public bool isLoginScene = true;

    private void Start()
    {
        if (quitGame == null)
            FindObjectOfType<SCR_QuitGame>();
        if(isLoginScene)
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
        if(isLoginScene)
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

    public void ShowInfo()
    {
        informationPanel.SetActive(true);
    }

    public void HideInfo()
    {
        informationPanel.SetActive(false);
    }

    public void ShowCreditos()
    {
        creditosPanel.SetActive(true);
    }

    public void HideCreditos()
    {
        creditosPanel.SetActive(false);
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
