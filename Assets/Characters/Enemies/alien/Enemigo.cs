using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class Enemigo : MonoBehaviour {

    
    Transform Objetivo;     //Personaje principal  
    public float DistanciaDetec;     //Distancia de deteccion
    public float DistanciaNear = 3;     //Distancia maxima del acercamiento del personaje
    public float speed;         //Velocidad de movimiento
    Vector3 Direccion;          //Direccion de movimiento

    static Animator anim;

    void Start () {

        //Encontramos el personaje principal usando Tags
        Objetivo = GameObject.FindGameObjectWithTag("Personaje").transform;

        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Vector3.Distance(Objetivo.transform.position, transform.position) < DistanciaDetec && Vector3.Distance(Objetivo.transform.position, transform.position) >= DistanciaNear)
        {
            Direccion = Objetivo.transform.position;        //Guarda la posicion del personaje principal
            float MovimientoFluido = speed * Time.deltaTime;        //Da un movimiento fluido

            transform.position = Vector3.MoveTowards(transform.position, Direccion, MovimientoFluido);      //El enemigo persigue

            anim.SetBool("Detectado", true);
        }

        else if(Vector3.Distance(Objetivo.transform.position, transform.position) < DistanciaNear) {

            anim.SetBool("Detectado", true);
        }

        else
        {
            anim.SetBool("Detectado", false);
        }
       
    }
}
