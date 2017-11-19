using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour {

	private float MIN_TIME = 5f, MAX_TIME = 10f;
	private float user_relaxation_time = 2f;
	private float spawnFreq;
	private Vector3 offset = Vector3.zero;
	private Animator animator1, animator2;

	void Start () {
		spawnFreq = Random.Range (MIN_TIME, MAX_TIME);
		Invoke("ini", spawnFreq);
		animator1 = transform.Find ("Post").GetComponent<Animator> ();
		animator2 = transform.Find ("Post1").GetComponent<Animator> ();
	}

	void ini()
	{
		animator1.SetTrigger("Incoming");
		animator2.SetTrigger ("Incoming");
		Invoke("spawn", user_relaxation_time);
	}

	void spawn () {
		//	offset.x = gameObject.transform.position.z;
		animator1.SetTrigger("Incoming");
		animator2.SetTrigger("Incoming");
		GameObject curSpawn = KaChow.Instance.trainPrefab;
		GameObject vehicle = Instantiate (curSpawn, offset, Quaternion.identity); 
		vehicle.transform.SetParent (gameObject.transform);
		if (transform.parent.transform.parent.transform.tag == "RotatedRoad") 
		{
			vehicle.transform.Rotate (new Vector3 (0f, 180f, 0f));
		}
		vehicle.transform.localPosition = offset;
		Invoke("ini", spawnFreq);
	}
}
