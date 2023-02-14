using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    Vector2 Enemy;             //hubica al enemi
    public GameObject playerM; //para que se mueva
    bool perseguirP;           //ira al infiltrado
    public int vel;            //un entero 

    // Update is called once per frame
    void Update()
    {
        if(perseguirP)   //se declara pa si perseguira
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemy, vel * Time.deltaTime);//empesar a perseguir

        }

        if(Vector2.Distance(transform.position, Enemy)>5f) //tamaño del rango que perseguira
        {
            perseguirP = false;    // cuando estemos en el rango
        }

    }

    private void OnTriggerStay2D(Collider2D collision)  //cuando este dentro de la colicion nos perseguira
    {
        if(collision.tag.Equals("Player"))
        {
            Enemy = playerM.transform.position; //perseguira el guardia
            perseguirP = true;             //cuando nos persiga sea verdadero
        }
    }

}
