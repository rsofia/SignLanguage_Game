using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Minijuegos
{
   

    public class SCR_Minigame : MonoBehaviour
    {

        [HideInInspector]
        public bool isGamePaused = false;       

        [Header("User Interface")]
        [Tooltip("Three hearts for three mistakes")]
        public Image[] hearts = new Image[3];
        private int currentLife = 3;
        [Tooltip("Menu to show when game is paused. Should have a button to play again.")]
        public GameObject pausePanel;
        public GameObject gameOverPanel;

        [Header("Juego Actual")]
        public SCR_MinigameManager gameManager;

        [Header("Puntaje Final")]
        [Range(0, 6)]
        private int puntajeFinal = 0; //Estas son las estrellas. Maximo 3, cada una con mitades.

        [Header("Estrellas")]
        public SCR_StarSystem starSystem;


        public void Iniciar()
        {
            currentLife = hearts.Length;
            gameOverPanel.SetActive(false);
            Resume();
        }

        #region VIDA
        public void RestLife()
        {
            currentLife--;
            if (currentLife <= 0)
            {
                currentLife = 0;
                GameOver("Se acabaron las vidas");
            }
            for(int i = 0; i < hearts.Length; i++)
            {
                if (i < currentLife)
                    hearts[i].gameObject.SetActive(true);
                else
                    hearts[i].gameObject.SetActive(false);
            }
        }
#endregion 

        #region GAME STATES
        public void Pause()
        {
            isGamePaused = true;
            pausePanel.SetActive(true);
        }
        public void Resume()
        {
            isGamePaused = false;
            pausePanel.SetActive(false);
        }
        public void GameOver(string _mssg, bool _didWin = false)
        {
            CalcularPuntaje(gameManager.GetUserScore(), gameManager.GetMaxPossibleScore(), gameManager.GetTimeLimit(), _didWin);
            isGamePaused = true;
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.Find("txtMssgGameOver").gameObject.GetComponent<Text>().text = _mssg;
        }

        #endregion

        #region Final score
        private void CalcularPuntaje(int _userScore, int _maxPossibleScore, float _finalTime, bool _didWin)
        {
            if(_didWin)
            {
                if(gameManager.hasTimeLimit)
                {
                    float thirdOfTime = gameManager.GetMaxTimeLimit() / 3;
                    if (gameManager.timeLimit >= gameManager.GetMaxTimeLimit() - thirdOfTime && currentLife == hearts.Length)
                    {
                        puntajeFinal = 6;
                    }
                    else if ((gameManager.timeLimit <= gameManager.GetMaxTimeLimit() - (thirdOfTime * 2)) || (currentLife < hearts.Length))
                    {
                        puntajeFinal = 5;
                    }
                    else
                    {
                        puntajeFinal = 4;
                    }
                }
                else
                {
                    if (currentLife == hearts.Length)
                    {
                        puntajeFinal = 6;
                    }
                    else if (currentLife < hearts.Length)
                    {
                        puntajeFinal = 5;
                    }
                    else
                    {
                        puntajeFinal = 4;
                    }
                }          
               
            }
            else
            {
                if (gameManager.hasTimeLimit)
                {
                    //FALTA AQUI 
                    float thirdOfTime = gameManager.GetMaxTimeLimit() / 3;
                    float maxScore = gameManager.GetMaxPossibleScore();
                    float userScore = gameManager.GetUserScore();
                    float fourthOfMaxScore = maxScore / 4;

                    if (userScore >= (fourthOfMaxScore * 3) || gameManager.timeLimit >= gameManager.GetMaxTimeLimit() - thirdOfTime)
                    {
                        puntajeFinal = 4;
                    }
                    else if (userScore >= (fourthOfMaxScore * 2)  || gameManager.timeLimit >= gameManager.GetMaxTimeLimit() - (thirdOfTime * 2))
                    {
                        puntajeFinal = 3;
                    }
                    else if (userScore >= (fourthOfMaxScore) || gameManager.timeLimit > 0)
                    {
                        puntajeFinal = 2;
                    }
                    else if (userScore == 0)
                    {
                        puntajeFinal = 0;
                    }
                    else
                    {
                        puntajeFinal = 1;
                    }

                }
                else
                {
                    float maxScore = gameManager.GetMaxPossibleScore();
                    float userScore = gameManager.GetUserScore();
                    float fourthOfMaxScore = maxScore / 4;

                    if (userScore >= (fourthOfMaxScore * 3))
                    {
                        puntajeFinal = 4;
                    }
                    else if (userScore >= (fourthOfMaxScore * 2))
                    {
                        puntajeFinal = 3;
                    }
                    else if (userScore >= (fourthOfMaxScore))
                    {
                        puntajeFinal = 2;
                    }
                    else if (userScore == 0)
                    {
                        puntajeFinal = 0;
                    }
                    else
                    {
                        puntajeFinal = 1;
                    }
                }
            }

            Debug.Log("Puntaje Final: " + puntajeFinal);
            starSystem.FillStarsWithScore(puntajeFinal);
        }
        #endregion
    }
}

