using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Transform player;           // donde esta el guardia
    public Transform head;             // parte de la linterna la base

    [Range(0f, 360f)]
    public float visionAngular = 30f;   //angulo de vicion de la linterna
    public float visionDistansia = 10f; //con el area asta donde puede ver

    bool detectar = false;   // el personaje si esta detectando

    private void Update()
    {
        detectar = false;
        Vector2 playerVector = player.position - head.position;   //si la linea que va de la linetrna asia el jugador y lo detecta esta en el campo de vicion
        if(Vector3.Angle(playerVector.normalized, head.right)< visionAngular * 0.5f)  
        {
            if(playerVector.magnitude < visionDistansia)
            {
                detectar = true;         //deteccion del player
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (visionAngular<= 0f) return;    //como se proyectara en la pantalla 

        float halfVisionAngular = visionAngular * 0.5f;          //el angulo que va tener

        Vector2 p1, p2;

        p1 = pointForAngle(halfVisionAngular, visionDistansia);    //posicion x y
        p2 = pointForAngle(-halfVisionAngular, visionDistansia);

        Gizmos.color = detectar?Color.green: Color.red; //color de deteccion
        Gizmos.DrawLine(head.position, (Vector2)head.position + p1);  //proyecta la sons que estara la linea de la linterna
        Gizmos.DrawLine(head.position, (Vector2)head.position + p2);  //proyecta la sons que estara la linea de la linterna

        Gizmos.DrawRay(head.position, head.right * 4f);   //Dibuja la line desde la linterna 
    }

    Vector3 pointForAngle(float angulo, float distancia)
    {
        return head.TransformDirection(new Vector2(Mathf.Cos(angulo * Mathf.Deg2Rad), // la distancia en la que deve estar
            Mathf.Sin(angulo * Mathf.Deg2Rad)))
            * distancia;
    }


}
