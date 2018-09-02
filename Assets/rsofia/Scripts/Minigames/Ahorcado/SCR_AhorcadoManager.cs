using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minijuegos
{
    public class SCR_AhorcadoManager : SCR_MinigameManager
    {
        [Header("Palabra(s) a Decifrar")]
        public string[] words;

        [Header("Prefab Parent")]
        public Transform letterParent;

        [Header("Prefabs")]
        [Tooltip("Prefab de un input field para mostrar la letra ")]
        public GameObject letterPrefab;
        [Tooltip("Prefab de una linea en blanco para insertar un espacio")]
        public GameObject blankPrefab;

        [Header("Score")]
        private int scorePerGuessedLetter = 1;

        private void Start()
        {
            nivelDificultad = SCR_CreateMinigamWith.nivelDificultadGlobal;
            //Ahorcado no va a tener categoria, asi que no la vamos a asignar

            minigame = GetComponent<SCR_Minigame>();
            CreateProceduralLevel();
            SetMaxPossibleScore();
            UpdateScore();
        }

        #region SCORE
        public override void AddScore()
        {
            base.AddScore();
            score += scorePerGuessedLetter;
        }

        public override void SetMaxPossibleScore()
        {
            base.SetMaxPossibleScore();
            //El puntaje maximo es igual al numero de letras que tiene cada palabra
            foreach(string palabra in words)
            {
                foreach(char letra in palabra)
                {
                    if (letra != ' ' && letra != 0)
                        maxPossibleScore++;
                }
            }
        }
        #endregion

        #region WIN
        public override void CheckIfGameWon()
        {
            base.CheckIfGameWon();
        }
        #endregion

        #region LEVEL
        public override void CreateProceduralLevel()
        {
            base.CreateProceduralLevel();
            GameObject temp;
            foreach (string palabra in words)
            {
                foreach (char letra in palabra)
                {
                    if (letra != ' ' && letra != 0)
                    {
                        temp = Instantiate(letterPrefab, letterParent);
                        temp.GetComponent<SCR_Ahorcado_Letra>().Init(letra);
                    }
                    else
                        Instantiate(blankPrefab, letterParent);
                }
                Instantiate(blankPrefab, letterParent);
            }

        }
        #endregion
    }
}
