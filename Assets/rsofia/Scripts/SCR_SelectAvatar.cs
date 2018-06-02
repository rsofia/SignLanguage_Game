using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SCR_SelectAvatar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int index;
    public GameObject submenu;
    private bool wasClickedOn = false;

    void Start()
    {
        submenu.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        submenu.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exit" + wasClickedOn);
        if (!wasClickedOn)
            submenu.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        wasClickedOn = !wasClickedOn;
        Debug.Log("Was clicked on");
    }

}
