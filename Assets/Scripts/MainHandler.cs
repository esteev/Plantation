using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHandler : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void loadEndless()
	{
		SceneManager.LoadScene ("Endless");
	}

	public void loadCrossy()
	{
		SceneManager.LoadScene ("Cross");
	}
}
