using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private float velovidadMov;

    [SerializeField] private Transform[] puntosMov;

    [SerializeField] private float distanciaMin;

    private int numAleatorio;
    

    private void Start()
    {
        numAleatorio = Random.Range(0, puntosMov.Length);
        
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMov[numAleatorio].position,
            velovidadMov * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosMov[numAleatorio].position)<distanciaMin)
        {
            numAleatorio = Random.Range(0, puntosMov.Length);
            // Gira
        }
    }
}
