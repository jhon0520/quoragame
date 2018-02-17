/**
 * Universidad Autónoma de Occidente - 2018
 *
 * doorOpen.
 *
 * @autor Cesar Salazar <cesar0572011@hotmail.com>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour {



    GameObject doorL;
    GameObject doorR;
    GameObject targetL;
    GameObject targetR;
    GameObject mid;

    AudioSource au;
    ParticleSystem psLe;
    ParticleSystem psRe;
    float distance1;
    float distance2;
    bool open = false;

    void Start()
    {
        psLe = GameObject.Find("SteamL").GetComponent<ParticleSystem>();
        psRe = GameObject.Find("SteamR").GetComponent<ParticleSystem>();
        au = gameObject.GetComponent<AudioSource>();
        doorL = GameObject.Find("DoorL");
        doorR = GameObject.Find("DoorR");
        targetL = GameObject.Find("refLeft");
        targetR = GameObject.Find("refRight");
        mid = GameObject.Find("middle");
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, targetL.transform.position, 0.05f);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, targetR.transform.position, 0.05f);
        }
        if (open == false)
        {
            doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, mid.transform.position, 0.05f);
            doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, mid.transform.position, 0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("P1"))
        {
            Debug.Log("entro");
            open = true;
            var Le = psLe.emission;
            var Re = psRe.emission;
            psLe.Play();
            psRe.Play();
            Le.enabled = true;
            Re.enabled = true;
            
            au.Play();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            Debug.Log("salio");
            open = false;

        }
    }
}