using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour {
	private float distanceMagnitude = 0.4f;
	private float speed = 0.01f,rotationSpeed = 5f;
	private Vector3 toMove;
	private float toRotate,currentAngle;
	private float tapCount = 0;
	private Animator animator;
	public enum RotationSide { up,right,down,left};
	public float[,] rotationTable = {   {0,90,180,-90 },
		{-90,0,90,180 },
		{180,-90,0,90 },
		{90,180,-90,0 }
	};
	RotationSide lastRotation;
	void Start () {
		animator = transform.GetChild (0).GetComponent<Animator> ();
		//transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		toMove = transform.position;
		currentAngle = toRotate = transform.rotation.eulerAngles.y ;
	}

	float horizontal, vertical;
	Vector3 tempRotation;
	float tempRotationY;
	void Update () {

		if (toMove != transform.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, toMove, speed);
		}
		else
		{
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");

			// oldPosition = transform.position;
			//if swipe
			if (Mathf.Abs(horizontal) > 0|| Mathf.Abs(vertical) > 0)
			{
				//both active disactivate one
				animator.SetTrigger("Jump");
				if (Mathf.Abs(horizontal) > 0 && Mathf.Abs(vertical) > 0) horizontal = 0;
				toMove += new Vector3(horizontal* distanceMagnitude, 0f, vertical *distanceMagnitude);
			}

		}
		if (toRotate != currentAngle) {

			tempRotationY = Mathf.MoveTowards(currentAngle, Mathf.Abs(toRotate)
				,toRotate<0?-1*rotationSpeed:rotationSpeed);

			tempRotation = MakeVectorY(tempRotationY);
			transform.rotation = Quaternion.Euler(tempRotation);
			currentAngle = tempRotationY;
		}
		else
		{
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");
			//if swipe   
			if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical)>0){
				//up swipe
				if (vertical == 1)
				{   
					toRotate = rotationTable[(int)lastRotation,(int)RotationSide.up];
					lastRotation = RotationSide.up;
				}
				//down swipe
				else if (vertical == -1)
				{


					toRotate = rotationTable[(int)lastRotation, (int)RotationSide.down];
					lastRotation = RotationSide.down;
				}
				//left swipe
				else if (horizontal == 1)
				{


					toRotate = rotationTable[(int)lastRotation, (int)RotationSide.right];
					lastRotation = RotationSide.right;
				}
				//right swipe
				else if(horizontal==-1) {

					toRotate = rotationTable[(int)lastRotation, (int)RotationSide.left];
					lastRotation = RotationSide.left;

				}
				toRotate += currentAngle;
			}
		}
		if (Input.GetButtonUp("Fire1"))
		{
			if (currentAngle %90== 0)
				toRotate = currentAngle + rotationTable[(int)lastRotation, (int)RotationSide.up];

			lastRotation = RotationSide.up;
			toMove += new Vector3(0f, 0f, distanceMagnitude);
		}

	}
	Vector3 MakeVectorY(float vectorY)
	{
		return new Vector3(0f, vectorY, 0f);
	}

}