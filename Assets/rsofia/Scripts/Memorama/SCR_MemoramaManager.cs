using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_MemoramaManager : MonoBehaviour {

    [Header("Randomize")]
    public SCR_MemoramaCard[] cards;
    private List<SCR_MemoramaCard> currentTurnedCards = new List<SCR_MemoramaCard>();

    [Header("User Interface")]
    [Tooltip("Text to display the score")]
    public Text txtScore;
    [Tooltip("Leave null if there will be no time limit.")]
    public Text txtTimeCountDown;

    [Header("Time Limit")]
    public bool hasTimeLimit = false;
    [Tooltip("Time limit in seconds")]
    public float timeLimit = 0.0f;
    private float deltaTime = 0.1f;
    private string timeString = "00:00";

    private int score = 0;
    private int scorePerPair = 10;

    private void Start()
    {
        UpdateScore();
        BeginCountdown();
    }

    #region CARD DISPLAY
    private void RandomizeCards()
    {

    }
    public void AddACard(SCR_MemoramaCard _card)
    {
        currentTurnedCards.Add(_card);
        if (currentTurnedCards.Count > 2)
        {
            SCR_MemoramaCard firstCard = currentTurnedCards[0];
            currentTurnedCards.Remove(currentTurnedCards[0]);
            firstCard.Turn();
        }
    }
    public bool IsCardTurned(SCR_MemoramaCard _card)
    {
        return currentTurnedCards.Find(x => _card);
    }
    public void RemoveACard(SCR_MemoramaCard _card)
    {
        currentTurnedCards.Remove(_card);
    }
    #endregion

    #region SCORE
    public void AddScore()
    {
        score += scorePerPair;
        UpdateScore();
    }

    private void UpdateScore()
    {
        txtScore.text = score.ToString();
    }
    #endregion

    #region GAME STATES
    public void GameOver()
    {

    }

    public void GameWon()
    {

    }
    #endregion

    #region TIME
    private void BeginCountdown()
    {
        if (hasTimeLimit && timeLimit > 0)
        {
            StartCoroutine(UpdateSeconds());
        }
        else
            Debug.Log("Minigame with no time limit");
    }

    IEnumerator UpdateSeconds()
    {
        timeString = string.Format("{0}:{1:00}", (int)timeLimit / 60, (int)timeLimit % 60);
        txtTimeCountDown.text = timeString;
        yield return new WaitForSeconds(deltaTime);
        timeLimit -= deltaTime;
        if (timeLimit <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(UpdateSeconds());
        }
    }

#endregion
}
