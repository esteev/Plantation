using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenerySpawner : MonoBehaviour {

	private float type1GreeneryChance = 0.2f;
	private float type2GreeneryChance = 0.4f;

	void Start () {
		greenify ();
	}

	void greenify()
	{
		float chance;
		foreach(Transform greenBlock in transform)
		{
			foreach (Transform placeHolder in greenBlock) 
			{
				chance = Random.Range (0f, 1f);
				if (greenBlock.tag == "Type1") 
				{
					if (chance < type1GreeneryChance) 
					{
						GameObject lush = Instantiate (KaChow.Instance.trees [Random.Range (0, KaChow.Instance.trees.Length)], placeHolder.transform.position, Quaternion.identity);
						lush.transform.SetParent (placeHolder.transform);
					}
				} 
				else if (greenBlock.tag == "Type2") 
				{
					if (chance < type2GreeneryChance) 
					{
						GameObject lush = Instantiate (KaChow.Instance.trees [Random.Range (0, KaChow.Instance.trees.Length)], placeHolder.transform.position, Quaternion.identity);
						lush.transform.SetParent (placeHolder.transform);
					}
				}
			}
		}	
	}
}
