using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION
{
    Up,
    Down,
    Left,
    Right
}

public class SCR_Level : MonoBehaviour {

    public bool isBlocked = true;

    public SCR_Level up;
    public SCR_Level down;
    public SCR_Level left;
    public SCR_Level right;

    public string sceneToLoad = "";

    private void Start()
    {
        if (isBlocked)
            GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f, 1.0f);
    }

    public SCR_Level GetLevelFromDirection(DIRECTION direction)
    {
        SCR_Level result = null;
        if (!isBlocked)
        {
            switch (direction)
            {
                case DIRECTION.Up:
                    {   if(up != null && !up.isBlocked)
                            result =  up;
                    }
                    break;
                case DIRECTION.Down:
                    {
                        if (down != null && !down.isBlocked)
                            result = down;
                    }
                    break;
                case DIRECTION.Left:
                    {
                        if (left != null && !left.isBlocked)
                            result = left;
                    }
                    break;
                case DIRECTION.Right:
                    {
                        if (right != null && !right.isBlocked)
                            result = right;
                    }
                    break;
            }
        }
        return result;
    }

    private void OnDrawGizmos()
    {
        if (up != null) DrawLine(up);
        if (right != null) DrawLine(right);
        if (down != null) DrawLine(down);
        if (left != null) DrawLine(left);
    }
    
    protected void DrawLine(SCR_Level pin)
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, pin.transform.position);
    }
}
