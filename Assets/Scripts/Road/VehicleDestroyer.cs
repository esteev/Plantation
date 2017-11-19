using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
//		print ("here");
		if(col.gameObject.tag=="Strip"||col.gameObject.tag=="RotatedRoad")
			Destroy (col.gameObject);
		else
			Destroy (col.gameObject.transform.parent.gameObject);
	}
}
