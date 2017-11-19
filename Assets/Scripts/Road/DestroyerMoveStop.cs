using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerMoveStop : MonoBehaviour {

	private bool started = false;

	void Start()
	{
		Invoke ("starter", 6f);
	}

	void Update () {
		if(started)
			transform.Translate (Vector3.left * Time.deltaTime * KaChow.Instance.roadSystemMoveSpeed);
	}

	void starter()
	{
		started = true;
	}
}
