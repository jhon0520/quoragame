using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource>();
		audio.PlayDelayed (100);
		audio.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
