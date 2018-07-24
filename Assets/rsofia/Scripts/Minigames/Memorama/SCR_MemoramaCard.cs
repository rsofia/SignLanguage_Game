using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minijuegos
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class SCR_MemoramaCard : MonoBehaviour
    {

        public SCR_MemoramaCard connection;
        public Sprite front;
        public Sprite back;

        private SpriteRenderer mySpriteRenderer;
        private Animator myAnim;
        private bool wasAMatch = false;
        private bool isHidden = true;
        private SCR_MemoramaManager memoramaManager;

        private void Start()
        {
            mySpriteRenderer = GetComponent<SpriteRenderer>();
            memoramaManager = FindObjectOfType<SCR_MemoramaManager>();
#if UNITY_EDITOR
            if (memoramaManager == null)
                Debug.LogError("HAY QUE AGREGAR MEMORAMA MANAGER");
#endif
            myAnim = GetComponent<Animator>();
            AssignConnectionToMyConnection();


            Hide();
        }

        public bool IsShowing()
        {
            return !isHidden;
        }

        //This function is in case the developer forgot to assing either connection
        private void AssignConnectionToMyConnection()
        {
            if (connection != null && connection.connection == null)
            {
                connection.connection = gameObject.GetComponent<SCR_MemoramaCard>();
            }
        }

        public void Turn()
        {
            if (!memoramaManager.minigame.isGamePaused)
                myAnim.SetTrigger("turn");
#if UNITY_EDITOR
            else
                Debug.Log("Game paused for some reason");
#endif
        }

        public void ChangeTurn()
        {
            if (isHidden)
                Show();
            else
                Hide();

        }

        private void Hide()
        {
            mySpriteRenderer.sprite = back;
            memoramaManager.RemoveACard(this);
            isHidden = true;
        }

        private void Show()
        {
            mySpriteRenderer.sprite = front;
            memoramaManager.AddACard(this);
            isHidden = false;

            StartCoroutine(WaitForCheck());
           
        }

        IEnumerator WaitForCheck()
        {
            yield return new WaitForEndOfFrame(); //Check if its connection is showing too
            if (connection != null && connection.connection != null)
            {
                if (connection.IsShowing() && memoramaManager.IsCardTurned(this) && memoramaManager.IsCardTurned(connection))
                {
#if UNITY_EDITOR
                    Debug.Log("2. They were indeed a match.");
#endif
                    wasAMatch = true;
                    memoramaManager.RemoveACard(this);
                    memoramaManager.RemoveACard(connection);
                    MarkAsCompleted();
                }
            }
        }

        public void MarkAsCompleted()
        {
            if (wasAMatch || connection.wasAMatch)
            {
#if UNITY_EDITOR
                Debug.Log("3. They were marked as a match!");
#endif
                StartCoroutine(WaitToMatch());
            }
            else
            {
                Debug.Log("3. They were NOT marked as a match!");
            }
        }

        IEnumerator WaitToMatch()
        {
            yield return new WaitForSeconds(0.85f);
            //add Score
            FindObjectOfType<SCR_MemoramaManager>().AddScore();
            //destroy this and connection
            connection.gameObject.SetActive(false);
            gameObject.SetActive(false);
            memoramaManager.CheckIfGameWon();
        }
    }
}

