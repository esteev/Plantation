using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLogMovement : MonoBehaviour {

	private float speed;

	void Start () {
		speed = transform.parent.transform.parent.transform.parent.GetComponent<RoadVariables>().roadObjectSpeed;
	}

	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * speed);
	}
}
