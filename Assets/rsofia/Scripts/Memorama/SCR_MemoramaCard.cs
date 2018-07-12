using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class SCR_MemoramaCard : MonoBehaviour {

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
        if (memoramaManager == null)
            Debug.LogError("HAY QUE AGREGAR MEMORAMA MANAGER");
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
        myAnim.SetTrigger("turn");
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

        //Check if its connection is showing too
        if (connection != null && connection.connection != null)
        {
            if (connection.IsShowing() && memoramaManager.IsCardTurned(this) && memoramaManager.IsCardTurned(connection))
            {
                memoramaManager.RemoveACard(this);
                memoramaManager.RemoveACard(connection);
                wasAMatch = true;
            }
        }
    }

    public void MarkAsCompleted()
    {
        if(wasAMatch)
        {
            StartCoroutine(WaitToMatch());
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
    }
}
