using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_QuitGame : MonoBehaviour {

    public GameObject warningExitPanel;

    private void Start()
    {
        CancelQuit();
    }

    public void OpenQuitPanel()
    {
        warningExitPanel.SetActive(true);
    }

    public void CancelQuit()
    {
        warningExitPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
