using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCR_Loading : MonoBehaviour {

    public GameObject loadingPanel;

    private void Start()
    {
        loadingPanel.SetActive(false);
    }

    public void LoadScene(string _sceneName)
    {
        StartCoroutine(WaitToLoad(_sceneName));
    }

    IEnumerator WaitToLoad(string _sceneName)
    {
        loadingPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(_sceneName);
    }

}
