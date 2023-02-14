using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float v_velovidadMov;

    [SerializeField] private Transform[] p_puntosMov;

    [SerializeField] private float d_distanciaMin;

    private int numAleatorio;
    

    private void Start()
    {
        numAleatorio = Random.Range(0, p_puntosMov.Length);
        
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, p_puntosMov[numAleatorio].position,
            v_velovidadMov * Time.deltaTime);

        if(Vector2.Distance(transform.position, p_puntosMov[numAleatorio].position)<d_distanciaMin)
        {
            numAleatorio = Random.Range(0, p_puntosMov.Length);
            // Gira
        }
    }
}
