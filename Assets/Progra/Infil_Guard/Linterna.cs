using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Transform p_player;           // donde esta el guardia
    public Transform h_head;             // parte de la linterna la base

    public float t_tiempo = 2f;
    public float tacumula = 0f;

    public string estadoActual = "normal";

    [Range(0f, 360f)]
    public float v_visionAngular = 30f;   //angulo de vicion de la linterna
    public float v_visionDistansia = 10f; //con el area asta donde puede ver

    bool detectar = false;   // el personaje si esta detectando

    private void Update()
    {
        detectar = false;
        Vector2 playerVector = p_player.position - h_head.position;   //si la linea que va de la linetrna asia el jugador y lo detecta esta en el campo de vicion
        if(Vector3.Angle(playerVector.normalized, h_head.right)< v_visionAngular * 0.5f)  
        {
            if(playerVector.magnitude < v_visionDistansia)
            {
                detectar = true;         //deteccion del player
                tacumula += Time.deltaTime;
                if(tacumula >= t_tiempo)
                {
                    //mi guardia pasa a estado de ataque
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (v_visionAngular<= 0f) return;    //como se proyectara en la pantalla 

        float halfVisionAngular = v_visionAngular * 0.5f;          //el angulo que va tener

        Vector2 p1, p2;

        p1 = pointForAngle(halfVisionAngular, v_visionDistansia);    //posicion x y
        p2 = pointForAngle(-halfVisionAngular, v_visionDistansia);

        Gizmos.color = detectar?Color.green: Color.red; //color de deteccion
        Gizmos.DrawLine(h_head.position, (Vector2)h_head.position + p1);  //proyecta la sons que estara la linea de la linterna
        Gizmos.DrawLine(h_head.position, (Vector2)h_head.position + p2);  //proyecta la sons que estara la linea de la linterna

        Gizmos.DrawRay(h_head.position, h_head.right * 4f);   //Dibuja la line desde la linterna 
    }

    Vector3 pointForAngle(float angulo, float distancia)
    {
        return h_head.TransformDirection(new Vector2(Mathf.Cos(angulo * Mathf.Deg2Rad), // la distancia en la que deve estar
            Mathf.Sin(angulo * Mathf.Deg2Rad)))
            * distancia;
    }


}
