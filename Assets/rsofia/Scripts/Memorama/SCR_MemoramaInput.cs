using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_MemoramaInput : MonoBehaviour {

    Ray cameraRay;
    RaycastHit hit;
    float maxDistanceRaycast = 10;
	
	void Update ()
    {
        if(Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            CheckCollisions();
        }
        
	}

    private void CheckCollisions()
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit, maxDistanceRaycast))
        {
            Debug.Log("Hit " + hit.collider.name);

            if (hit.collider.CompareTag("Card"))
            {
                hit.collider.gameObject.GetComponent<SCR_MemoramaCard>().Turn();
            }
        }
    }
}
