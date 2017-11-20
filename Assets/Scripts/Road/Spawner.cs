using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

	private const float stripWidth = 0.4f;
	private const int No_Of_Strips = 100;
	private const float chanceIncreaseFactor = 0.15f;
	private const float railRoadFactor = 0.1f;
	private const float waterStripFactor = 0.2f;
	private const int waterStripCount3Prob = 50, waterStripCount2Prob = 20, waterStripCount1Prob = 30;
	private const float MIN_SPEED = 0.3f, MAX_SPEED =  0.8f;

	public GameObject lGStrip, dGStrip, rStrip, tStrip, wStrip, roadSystemHolder;
	private GameObject curStrip, prevStrip;

	private Vector3 startPos = new Vector3(-30f, 0f, 0f);
	private Vector3 currentPos;

	void Start () {
		currentPos = startPos;
		prevStrip = null;
		instantiator (No_Of_Strips);
	}
		
	void instantiator(int n)
	{
		float tempChance = 0.4f + chanceIncreaseFactor;
		int times;
		GameObject tempInst = Instantiate (lGStrip, currentPos, Quaternion.identity);
		tempInst.transform.SetParent (roadSystemHolder.transform);
		prevStrip = lGStrip;
		currentPos = currentPos + new Vector3 (-1*stripWidth , 0f, 0f);
		for (int i = 1; i < n;i+=times) 
		{
			times = 1;
			float chance = Random.Range (0.0f, 1.0f);
			if (chance < tempChance) {
		//		print ("sadak");
				curStrip = rStrip;
				tempChance -= chanceIncreaseFactor;
			}
			else if(chance < tempChance + railRoadFactor)
			{
		//		print ("train");
				curStrip = tStrip;
				tempChance += chanceIncreaseFactor;
			}
			else if(chance < tempChance + waterStripFactor)
			{
		//		print ("paani");
				curStrip = wStrip;
				int waterStripsProb = Random.Range (0, 100);
				for (int j = (waterStripsProb>waterStripCount3Prob)?3:((waterStripsProb>waterStripCount2Prob+waterStripCount3Prob)?2:0); j > 0; j--) 
				{
					if (i + j <= n) 
					{
						times = j;
						j = -1;
					}	
				}
				tempChance += chanceIncreaseFactor;
			}
			else {
		//		print ("ghaas");
				if (prevStrip == lGStrip) {
					curStrip = dGStrip;
				} else {
					curStrip = lGStrip;
				}
				tempChance += chanceIncreaseFactor;
			}
			prevStrip = curStrip;
			for (int j = 0; j < times; j++) 
			{
				GameObject tempInst1 = Instantiate (curStrip, currentPos, Quaternion.identity) as GameObject;
				tempInst1.transform.SetParent (roadSystemHolder.transform);
				tempInst1.transform.localPosition = currentPos;
				tempInst1.AddComponent (System.Type.GetType("RoadVariables"));
				tempInst1.GetComponent<RoadVariables> ().roadObjectSpeed = Random.Range (MIN_SPEED, MAX_SPEED);
				if (Random.Range (0.0f, 1.0f) > 0.5f) 
				{
					tempInst1.transform.Rotate (new Vector3(0f,180f,0f));
					tempInst1.tag = "RotatedRoad";
				}
			//	print (tempInst1.ToString() + currentPos.ToString());
				currentPos = currentPos + new Vector3 (-1*stripWidth , 0f, 0f);
			}
			//GameObject tempRoad = Instantiate(curStrip, roadSystemHolder.transform.position, Quaternion.identity);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Cross");	
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();	
		}
	}

}
