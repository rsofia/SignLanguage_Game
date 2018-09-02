using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Minijuegos;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SCR_CreateMinigamWith : MonoBehaviour {

    [Header("Atributos de identificacion")]
    [Tooltip("El id con el que se identificara el juego para guardar su puntaje. Este debe ser SIN espacios ni caracteres especiales.")]
    public string levelID;

    [Header("Puntaje")]
    int puntaje = 0;
    public SCR_StarSystem sistemaDeEstrellas;

    [Header("Propiedades del juego")]
    public NIVEL_DIFICULTAD nivelDificultad;
    public CATEGORIA categoria;
    public MINIJUEGO minijuego;

    private Button myButton;

    [Header("Static")]
    public static NIVEL_DIFICULTAD nivelDificultadGlobal;
    public static CATEGORIA categoriaGlobal;
    public static string levelIDGlobal;

    private void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(() => GoToAndCreateMinigame());

        puntaje = SCR_Minigame.GetScoreFrom(levelID);
        sistemaDeEstrellas.FillStarsWithScore(puntaje);
    }

    public void GoToAndCreateMinigame()
    {
        switch(minijuego)
        {
            case MINIJUEGO.MEMORAMA:
                {
                    nivelDificultadGlobal = nivelDificultad;
                    categoriaGlobal = categoria;
                    levelIDGlobal = levelID;
                    SceneManager.LoadScene("Memorama_Minigame");
                }
                break;
            case MINIJUEGO.AHORCADO:
                {
                    nivelDificultadGlobal = nivelDificultad;
                    categoriaGlobal = categoria;
                    levelIDGlobal = levelID;
                    SceneManager.LoadScene("Ahorcado_Minigame");
                }
                break;
            default:
                Debug.Log("Game not found");
                break;
        }
    }


}
