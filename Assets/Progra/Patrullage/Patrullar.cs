using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float v_velovidadMov; // la velocidad en la que ira el guardia

    [SerializeField] private Transform[] p_puntosMov;  //puntos que se movera

    [SerializeField] private float d_distanciaMin; // que tenga distancia

    private int numAleatorio;  // controla a donde se va mover
    

    private void Start() 
    {
        numAleatorio = Random.Range(0, p_puntosMov.Length); // nuemro aleatorio

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, p_puntosMov[numAleatorio].position,  // mover al guardia
            v_velovidadMov * Time.deltaTime);                                                             // a donde queremos y la velocidad 

        if(Vector2.Distance(transform.position, p_puntosMov[numAleatorio].position)<d_distanciaMin) //condicion
        {
            numAleatorio = Random.Range(0, p_puntosMov.Length);  //cambiar a donde queremos que se mueva
            // movimiento
        }
    }
}
