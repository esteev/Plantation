using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaChow : MonoBehaviour {

	private static KaChow instance;
	public static KaChow Instance{get{ return instance; }}

	public GameObject[] vehicles;
	public GameObject[] waterItems;
	public GameObject trainPrefab;

	public int scoreEndless = 0;

	public float vehicleSpeed = 0.1f;
	public float roadSystemMoveSpeed = 0.2f;

	void Awake () {
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
		
	public void Save()
	{
		//PlayerPrefs.SetInt ("CurrentSkinPad", currentSkinIndexPad);
	
	}
		
}