using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Minijuegos
{
    public enum NIVEL_DIFICULTAD
    {
        PRINCIPIANTE,
        INTERMEDIO,
        AVANZADO,
        PROFESIONAL
    }

    public enum CATEGORIA
    {
        LETRAS,
        NUMEROS,
        CLASIFICADORES,
        OBJETOS,
        DELETREO,
        SALUDOS,
        ANIMALES
    }

    public enum MINIJUEGO
    {
        MEMORAMA,
        LOTERIA
    }

    public class SCR_MinigameManager : MonoBehaviour
    {
        [Header("Nivel Procedural")]
        public NIVEL_DIFICULTAD nivelDificultad;
        public CATEGORIA categoria;

        [Header("User Interface")]
        [Tooltip("Text to display the score")]
        public Text txtScore;
        [Tooltip("Leave null if there will be no time limit.")]
        public Text txtTimeCountDown;

        [Header("Score")]
        protected int score = 0;
        protected int maxPossibleScore;

        [Header("Time Limit")]
        [HideInInspector]
        public bool hasTimeLimit = false;
        [Tooltip("Time limit in seconds. Will be ignored if done procedurally.")]

        [HideInInspector]
        public float timeLimit = 0.0f;
        private float maxTimeLimit;
        protected float deltaTime = 0.1f;
        protected string timeString = "00:00";

        [HideInInspector]
        public SCR_Minigame minigame;

        public virtual void SetMaxPossibleScore()
        {

        }

        public int GetUserScore()
        {
            return score;
        }

        public int GetMaxPossibleScore()
        {
            return maxPossibleScore;
        }

        public virtual void CheckIfGameWon()
        {

        }

        public virtual void CreateProceduralLevel()
        {
            minigame.Iniciar();
        }

        public float GetMaxTimeLimit()
        {
            return maxTimeLimit;
        }

        public void SetTimeLimit(bool _hasTimeLimit, float _timeLimit = 0)
        {
            hasTimeLimit = _hasTimeLimit;
            timeLimit = _timeLimit;
        }

        #region SCORE

        public virtual void AddScore()
        {

        }

        protected void UpdateScore()
        {
            txtScore.text = score.ToString();
        }


        #endregion

        #region TIME
        protected void BeginCountdown()
        {
            txtTimeCountDown?.gameObject.SetActive(hasTimeLimit);
            if (hasTimeLimit && timeLimit > 0)
            {
                maxTimeLimit = timeLimit;
                StartCoroutine(UpdateSeconds());
            }
#if UNITY_EDITOR
            else
            {
                Debug.Log("Minigame with no time limit");
            }
#endif
        }

        public float GetTimeLimit()
        {
            return timeLimit;
        }
        
        IEnumerator UpdateSeconds()
        {
            timeString = string.Format("{0}:{1:00}", (int)timeLimit / 60, (int)timeLimit % 60);
            txtTimeCountDown.text = timeString;
            yield return new WaitForSeconds(deltaTime);
            if (!minigame.isGamePaused)
                timeLimit -= deltaTime;
            if (timeLimit <= 0)
            {
                minigame.GameOver("Se acabo el tiempo");
            }
            else
            {
                StartCoroutine(UpdateSeconds());
            }
        }

        #endregion
    }

}
