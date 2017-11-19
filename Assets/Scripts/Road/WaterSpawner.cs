using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour {

	private float MIN_TIME = 2f, MAX_TIME = 4f;
	private Vector3 offset = Vector3.zero;

	void Start () {
		Invoke("spawn", Random.Range (0f, MIN_TIME));
	}

	void spawn () {
		offset.x = gameObject.transform.position.z;
		offset.y = -0.7f;
		GameObject curSpawn = KaChow.Instance.waterItems[Random.Range(0, KaChow.Instance.waterItems.Length)];
		GameObject vehicle = Instantiate (curSpawn, offset, Quaternion.Euler(new Vector3(0f,90f,0f))); 
		vehicle.transform.SetParent (gameObject.transform);
		if (transform.parent.transform.parent.transform.tag == "RotatedRoad") 
		{
			vehicle.transform.Rotate (new Vector3 (0f, 180f, 0f));
		}
		vehicle.transform.localPosition = offset;
		int neg = (Random.Range (0, MAX_TIME)>MAX_TIME/2)?1:-1;
		Invoke("spawn", Random.Range (MIN_TIME, MAX_TIME));
	}
}
