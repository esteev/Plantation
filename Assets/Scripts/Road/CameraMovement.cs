using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * KaChow.Instance.roadSystemMoveSpeed);
	}
}
