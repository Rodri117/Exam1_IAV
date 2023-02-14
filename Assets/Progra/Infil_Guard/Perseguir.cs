using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    Vector2 e_Enemy;             //hubica al enemi
    public GameObject p_playerM; //para que se mueva
    bool p_perseguirP;           //ira al infiltrado
    public int vel;            //un entero 

    // Update is called once per frame
    void Update()
    {
        if(p_perseguirP)   //se declara pa si perseguira
        {
            transform.position = Vector2.MoveTowards(transform.position, e_Enemy, vel * Time.deltaTime);//empesar a perseguir

        }

        if(Vector2.Distance(transform.position, e_Enemy)>5f) //tamaño del rango que perseguira
        {
            p_perseguirP = false;    // cuando estemos en el rango
        }

    }

    private void OnTriggerStay2D(Collider2D collision)  //cuando este dentro de la colicion nos perseguira
    {
        if(collision.tag.Equals("Player"))
        {
            e_Enemy = p_playerM.transform.position; //perseguira el guardia
            p_perseguirP = true;             //cuando nos persiga sea verdadero
        }
    }

}
