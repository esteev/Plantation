using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleYCorrector : MonoBehaviour {

	private float smootheningUp = 0.01f;

	void OnTriggerStay(Collider col)
	{
	//	print ("res");
		if(col.gameObject.tag != "Destroyer")
			col.gameObject.transform.parent.transform.Translate(new Vector3(0f,smootheningUp,0f));
	}

}
