using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Minijuegos;
using UnityEngine.UI;
using System.IO;

public class SCR_GameManager : SCR_MinigameManager
{
    private int scorPerGesture = 1;
    private int totalGestures = 1;
    string pathToLoadGame = "";
    [Header("Gameflow")]
    public Button btnNextGesture;
    public Button btnFinishGame;
    List<string> gesturesToRead = new List<string>();
    int currentGesutre = 0;
    int numberOfGesturesMade = 0;
    public Text txtCurrentGesture;
    public s_ManagerLoadSign managerLoadSign;

    private void Start()
    {
        minigame = FindObjectOfType<SCR_Minigame>();
        pathToLoadGame = Application.dataPath + "/Archivos/PRINCIPAL/" + categoria.ToString() + ".txt";
        nivelDificultad = SCR_CreateMinigamWith.nivelDificultadGlobal;
        categoria = SCR_CreateMinigamWith.categoriaGlobal;
        InitScore();
        CreateProceduralLevel();
        hasTimeLimit = false;
    }

    #region SCORE
    public override void AddScore()
    {
        score += scorPerGesture;
        numberOfGesturesMade++;
        UpdateScore();
    }

    public void InitScore()
    {
        score = 0;
        UpdateScore();
    }

    public override void SetMaxPossibleScore()
    {
        maxPossibleScore = totalGestures * scorPerGesture;
    }
    #endregion

    public override void CheckIfGameWon()
    {
        base.CheckIfGameWon();
    }

    public override void CreateProceduralLevel()
    {
        base.CreateProceduralLevel();

        //Read current file to get the total max number of gestures
        if(File.Exists(pathToLoadGame))
        {
            string[] allLines = File.ReadAllLines(pathToLoadGame);
            foreach(string line in allLines)
            {
                //Solo agregarlo si no esta vacio y si no lo registramos ya (para evitar duplicados)
                if (!string.IsNullOrEmpty(line) && !gesturesToRead.Contains(line))
                    gesturesToRead.Add(line);
            }
        }

        if(gesturesToRead.Count > 0)
        {
            int gestureLimit = 0; //esto limita el numero de gestos (entre mayor dificultad, mas gestos)
            switch(nivelDificultad)
            {
                case NIVEL_DIFICULTAD.PRINCIPIANTE:
                    gestureLimit = 5;
                    break;
                case NIVEL_DIFICULTAD.INTERMEDIO:
                    gestureLimit = 8;
                    break;
                case NIVEL_DIFICULTAD.AVANZADO:
                    gestureLimit = 10;
                    break;
                case NIVEL_DIFICULTAD.PROFESIONAL:
                    gestureLimit = 15;
                    break;
            }

            while (gesturesToRead.Count > gestureLimit)
            {
                gesturesToRead.RemoveAt(Random.Range(0, gesturesToRead.Count - 1));

            }
        }
        SetCurrent();
        BeginCountdown();

    }

    /// <summary>
    /// Se salta el gesto actual y se va al siguiente (si es que exite)
    /// </summary>
    public void LoadNextGesture()
    {
        if (gesturesToRead.Count == 0)
            return;

        currentGesutre++;

        if (currentGesutre < gesturesToRead.Count)
        {
            SetCurrent();
        }


    }

    private void ShowNextButton()
    {
        //Si ya no hay un gesto despues de este, apagar el boton
        if (!(currentGesutre + 1 >= 0 && currentGesutre + 1 < gesturesToRead.Count))
        {
            btnNextGesture.gameObject.SetActive(false);
            btnFinishGame.gameObject.SetActive(true);
        }
        else
        {
            btnNextGesture.gameObject.SetActive(true);
            btnFinishGame.gameObject.SetActive(false);
        }
        

    }

    /// <summary>
    /// Sets the current geture to be tracked
    /// </summary>
    private void SetCurrent()
    {
        if (currentGesutre >= 0 && currentGesutre < gesturesToRead.Count)

        {
            txtCurrentGesture.text = gesturesToRead[currentGesutre].Split('-')[0];
            managerLoadSign.NombreDeArchivo = gesturesToRead[currentGesutre];
            managerLoadSign.ReadFile();
        }
        ShowNextButton();
    }


}
