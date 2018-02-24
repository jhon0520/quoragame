using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour {

	public enum ColletableType {BALAS, SANGRE, DINERO};
	public ColletableType Type;

    public static int BalasCount = 0;
	private int BalaValor = 10;


	// Use this for initialization
	void Start ()
    {
        Colletable.BalasCount += BalaValor;
		
	}
	

    void OnDestroy()
    {
        Colletable.BalasCount -= BalaValor;

        if (BalasCount <= 0)
        {
            Debug.Log("Has recogido todas las balas");
        }
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        if (OtherCollider.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }


}
