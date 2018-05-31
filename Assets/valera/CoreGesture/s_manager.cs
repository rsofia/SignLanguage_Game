using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Clase que hereda de s_leapHandGestureC dedicada para hacer override de las funciones para interpretar los gestos
 */
public class s_manager : s_LeapHandGestureC
{

    public Animator animcontroller;
    public GameObject Objeto;

    public float limineMin = 0.5f;
    public float limineMax = 0.6f;

    void Start ()
    {
        fn_initDetector();
    }
	
	void Update ()
    {
		
	}


    public override void fn_swipeLHdown()
    {
        base.fn_swipeLHdown();
        animcontroller.SetBool("morir", true);
        animcontroller.SetBool("caminar", false);

    }

    public override void fn_swipeLHright()
    {
        base.fn_swipeLHright();
        animcontroller.SetTrigger("atacar");

    }

    public override void fn_swipeLHup()
    {
        base.fn_swipeLHup();
        animcontroller.SetBool("morir", false);
        animcontroller.SetBool("caminar", false);
    }

    public override void fn_swipeLHleft()
    {
        base.fn_swipeRHleft();
        animcontroller.SetBool("morir", false);
        animcontroller.SetBool("caminar", true);
    }

    public override void fn_ZoomPositive(float _distance, float _multiply)
    {
        base.fn_ZoomPositive(_distance, _multiply);
        if (Objeto.transform.localScale.x < limineMax)
            Objeto.transform.localScale = Objeto.transform.localScale + (new Vector3(_distance, _distance, _distance) * Time.deltaTime);
    }
    public override void fn_ZoomNegative(float _distance, float _multiply)
    {
        base.fn_ZoomNegative(_distance, _multiply);
        if (Objeto.transform.localScale.x > limineMin)
            Objeto.transform.localScale = Objeto.transform.localScale - (new Vector3(_distance, _distance, _distance) * Time.deltaTime);
    }
}
