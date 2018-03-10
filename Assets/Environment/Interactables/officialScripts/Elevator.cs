/**
 * Universidad Autónoma de Occidente - 2018
 *
 * Elevator.
 *
 * @autor Cesar Salazar <cesar0572011@hotmail.com>
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Elevator : MonoBehaviour {


    GameObject lift;
    GameObject top;
    GameObject bottom;
    GameObject screen;
    AudioSource au;

    Renderer rd;
    Texture txtup;
    Texture txtdown;
    bool startMoving;
    bool liftEnable=false;
    bool once=true;
    float speed;
    bool up=true;
    // Use this for initialization
    void Start() {
        screen = GameObject.Find("screen");
        lift = GameObject.Find("Platform");
        top = GameObject.Find("top");
        bottom = GameObject.Find("bottom");
        speed = 0.9f * Time.deltaTime;
        au = lift.GetComponent<AudioSource>();
        txtup = Resources.Load("up") as Texture;
        txtdown = Resources.Load("down") as Texture;
        rd = screen.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        
        if (liftEnable)
        {
            if (up)
            {
                rd.material.mainTexture = txtup;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    startMoving = true;
                    if (once == true)
                    {
                        au.Play();
                        once = false;
                    }
                   
                }
                if (lift.transform.position != top.transform.position && startMoving == true)
                {
                    
                    lift.transform.position = Vector3.MoveTowards(lift.transform.position, top.transform.position, speed);
                    if (lift.transform.position.y == top.transform.position.y && startMoving)
                    {
                        startMoving = false;
                        up = !up;
                        once = true;
                    }
                }
            }


            if (up == false)
            {
                rd.material.mainTexture = txtdown;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    startMoving = true;
                    if (once == true)
                    {
                        au.Play();
                        once = false;
                    }
                }
                if (lift.transform.position != bottom.transform.position && startMoving == true)
                {

                    lift.transform.position = Vector3.MoveTowards(lift.transform.position, bottom.transform.position, speed);
                    if (lift.transform.position.y == bottom.transform.position.y && startMoving)
                    {
                        startMoving = false;
                        up = !up;
                        once = true;
                    }
                }

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            liftEnable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            liftEnable = false;
        }
    }
}
