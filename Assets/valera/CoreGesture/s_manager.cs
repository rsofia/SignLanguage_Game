using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Clase que hereda de s_leapHandGestureC dedicada para hacer override de las funciones para interpretar los gestos
 */
public class s_manager : s_LeapHandGestureC
{

	void Start ()
    {
        fn_initDetector();
    }
	
	void Update ()
    {
		
	}


    //public override void fn_swipeLHdown()
    //{
    //    base.fn_swipeLHdown();
    //    Debug.Log("otra");
    //}
}
