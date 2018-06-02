using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AVATAR
{
    DEFAULT,
    ONE,
    TWO,
    THREE
}

public class SCR_Avatars : MonoBehaviour {
    public AVATAR myAvatar;
    public SCR_SelectAvatar selectAvatar;
    private Button myButton;
    public Image imgAvatar;
    public Sprite[] spritesForAvatars;
    public bool addListener = true;

    private void Start()
    {
        if (selectAvatar == null)
            selectAvatar = FindObjectOfType<SCR_SelectAvatar>();
        myButton = GetComponent<Button>();
        AssingAvatar();
        if (addListener)
        {
            myButton.onClick.AddListener(ChangeListener);
        }
    }

    public void ChangeListener()
    {
        AVATAR tempAvatar = selectAvatar.GetComponent<SCR_Avatars>().myAvatar;
        selectAvatar.GetComponent<SCR_Avatars>().myAvatar = myAvatar;
        myAvatar = tempAvatar;
        AssingAvatar();
        selectAvatar.GetComponent<SCR_Avatars>().AssingAvatar();        
    }

    public void AssingAvatar()
    {
        imgAvatar.sprite = spritesForAvatars[(int)myAvatar];
    }

}
