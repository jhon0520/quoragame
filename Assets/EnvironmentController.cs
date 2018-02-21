using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour {

	/**
	 * Al iniciar la pantalla ejecute un audio infinitamente.
	 */
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.PlayDelayed (100); // Espere 100 milisegundos antes de iniciar.
		audio.loop = true;
	}

}
