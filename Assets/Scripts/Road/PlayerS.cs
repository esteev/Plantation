using UnityEngine;
using System.Collections;

public class PlayerS : MonoBehaviour {

	private const float stripWidth = 0.4f;

	public Vector3 nextDir;

	public float jumpForce=100;

	public float speed=5;
	public float speedRot=100;

	public float rotationOffset;

	Rigidbody rb;

	public Vector3 curPosition;

	void Start () {
		rb = GetComponent<Rigidbody> ();

		curPosition=transform.position;

	}

	void Update () {


		if(transform.position!= new Vector3(curPosition.x,transform.position.y,curPosition.z) +nextDir)
		{

			transform.position=Vector3.MoveTowards (transform.position, new Vector3 (curPosition.x, transform.position.y, curPosition.z) + nextDir, speed * Time.deltaTime);

			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (Quaternion.Euler(0,rotationOffset,0)*nextDir), speedRot * Time.deltaTime);

		}else{
			nextDir = Vector3.zero;
			curPosition=transform.position;
			curPosition.x = Mathf.Round (curPosition.x);
			curPosition.y = Mathf.Round (curPosition.y);


			if (Input.GetAxisRaw ("Horizontal") != 0) {

				nextDir.z = Mathf.Sign(-Input.GetAxisRaw ("Horizontal")) * stripWidth;
	//			nextDir.z = 0.4f;
				Move ();

			} else if (Input.GetAxisRaw ("Vertical") != 0) {


				nextDir.x = Mathf.Sign(Input.GetAxisRaw ("Vertical")) * stripWidth;
		//		nextDir.x = 0.4f;
				Move ();
			}
		}
	}
		
	void Move()
	{
		rb.AddForce (0, jumpForce, 0);
	}
}
