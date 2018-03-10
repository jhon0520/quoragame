using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class Enemigo : MonoBehaviour {

    
    Transform Objetivo;     //Personaje principal  
    public float DistanciaDetec;     //Distancia de deteccion
    public float DistanciaNear = 3;     //Distancia maxima del acercamiento del personaje
    public float speedMov;         //Velocidad de movimiento
    public float speedRot;         //Velocidad de rotacion
    Vector3 Direccion;          //Direccion de movimiento
    Vector3 DireccionRotacion;  //Mantener frente al enemigo

    static Animator anim;

    void Start () {

        //Encontramos el personaje principal usando Tags
        Objetivo = GameObject.FindGameObjectWithTag("P1").transform;

        anim = GetComponent<Animator>();

    }


    void Update()
    {
        if (Vector3.Distance(Objetivo.transform.position, transform.position) < DistanciaDetec && Vector3.Distance(Objetivo.transform.position, transform.position) >= DistanciaNear)
        {
            //Rotacion
            DireccionRotacion = Objetivo.position - transform.position; //halla la linea entre el enemigo y el personaje
            float MovimientoFluidoRot = speedRot * Time.deltaTime;        //Da un movimiento fluido
            DireccionRotacion.y = 0; //no se rota en el eje y
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DireccionRotacion), MovimientoFluidoRot); // rota

            //Desplazamiento
            Direccion = Objetivo.transform.position;        //Guarda la posicion del personaje principal
            float MovimientoFluido = speedMov * Time.deltaTime;        //Da un movimiento fluido
            transform.position = Vector3.MoveTowards(transform.position, Direccion, MovimientoFluido);      //El enemigo persigue

            anim.SetBool("Detectado", true);
        }

        else if(Vector3.Distance(Objetivo.transform.position, transform.position) < DistanciaNear) {

            //Rotacion
            DireccionRotacion = Objetivo.position - transform.position; //halla la linea entre el enemigo y el personaje
            float MovimientoFluidoRot = speedRot * Time.deltaTime;        //Da un movimiento fluido
            DireccionRotacion.y = 0; //no se rota en el eje y
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DireccionRotacion), MovimientoFluidoRot); // rota

            anim.SetBool("Detectado", true);
        }

        else
        {
            anim.SetBool("Detectado", false);
        }
       
    }
}
