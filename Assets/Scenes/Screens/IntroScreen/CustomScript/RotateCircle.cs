using UnityEngine;
using System.Collections;

public class RotateCircle : MonoBehaviour {
	public float direction = 1.0f;
	public float speed = 9.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * direction);
	}
}
