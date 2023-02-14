using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRaton : MonoBehaviour
{
    private float velocidad = 5f;   //la velocidad del cubo
    private Vector3 posicionObj;    //es la posicion en la que se movera con el raton

    // Start is called before the first frame update
    void Start()
    {

        posicionObj = this.transform.position;   // inicializamos la posicion del cubo

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // el boton del raton hace click
        {
            posicionObj = Camera.main.ScreenToWorldPoint(Input.mousePosition);           //asigna la posicion de la pantalla con la del raton
            posicionObj.z = this.transform.position.z;                                   //en un punto del mundo para posicionar el cubo
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, posicionObj, velocidad * Time.deltaTime);  //la velocidad a la que ira en el mundo
    }
}
