using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour {

	private float speed = 5f;
	private float sensitivity = 0.001f;
	private Animator animator;
	private Vector3 nextVec = new Vector3(0f, 0f, -0.4f), targetPos;
	private bool jump = false;
	private int nJump = 0;
	private List<Vector3> arrayPos = new List<Vector3>();

	void Start () {
		animator = transform.GetChild(0).GetComponent<Animator> ();
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
		}

		if (jump) 
		{
			if (Mathf.Abs (transform.position.z - arrayPos[0].z) > sensitivity) {
				transform.position = Vector3.MoveTowards (transform.position, arrayPos[0], speed * Time.deltaTime);
			} else {
				jump = false;
				arrayPos.RemoveAt (0);
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			if (arrayPos.Count == 0) {
				arrayPos.Add (transform.position + nextVec);
			}
			else {
				arrayPos.Add (arrayPos [arrayPos.Count - 1] + nextVec);
			}
			nJump++;
			//            StartCoroutine(wait());
		}

		if (nJump>0&&!jump)
		{
			foreach(Vector3 x in arrayPos)
				print (x);
			animator.SetTrigger ("Jump");
			nJump--;
			StartCoroutine (wait ());
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (0.5f);
		jump = true;
	}
}

