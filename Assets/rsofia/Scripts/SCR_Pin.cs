using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Pin : MonoBehaviour {

    public SCR_Level currentLevel;
    public Text txtLevelSelected;
    private SCR_Level targetLevel;
    private bool isMoving = false;

    private void Start()
    {
        SetCurrentLevel(currentLevel);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            SetDirection(DIRECTION.Up);
        else if (Input.GetKeyDown(KeyCode.DownArrow) | Input.GetKeyDown(KeyCode.S))
            SetDirection(DIRECTION.Down);
        else if (Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.D))
            SetDirection(DIRECTION.Right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown(KeyCode.A))
            SetDirection(DIRECTION.Left);

    }

    private void SetDirection(DIRECTION _dir)
    {
        SCR_Level level = currentLevel.GetLevelFromDirection(_dir);

        if (level != null)
            SetCurrentLevel(level);
    }
    

    public void SetCurrentLevel(SCR_Level _level)
    {
        currentLevel = _level;
        txtLevelSelected.text = currentLevel.sceneToLoad;
        transform.position = currentLevel.transform.position;
    }

}
