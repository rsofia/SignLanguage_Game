using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Minijuegos;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SCR_CreateMinigamWith : MonoBehaviour {

    public NIVEL_DIFICULTAD nivelDificultad;
    public CATEGORIA categoria;
    public MINIJUEGO minijuego;

    [Header("Prefabs")]
    public GameObject memoramaPrefab;

    private Button myButton;

    [Header("Static")]
    public static NIVEL_DIFICULTAD nivelDificultadGlobal;
    public static CATEGORIA categoriaGlobal;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => GoToAndCreateMinigame());
    }

    public void GoToAndCreateMinigame()
    {
        switch(minijuego)
        {
            case MINIJUEGO.MEMORAMA:
                {
                    nivelDificultadGlobal = nivelDificultad;
                    categoria = categoriaGlobal;
                    SceneManager.LoadScene("Memorama_Minigame");
                }
                break;
            default:
                Debug.Log("Game not found");
                break;
        }
    }


}
