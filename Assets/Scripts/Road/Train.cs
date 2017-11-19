using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

	private float speed = 5f;

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
