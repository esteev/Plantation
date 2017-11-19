using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endlessMonkey
{
    public class Obstacle : MonoBehaviour
    {
        private float speed = 0.15f;
        public float spawnFrequency = 2f;
		private bool countable = true;
        void Update()
        {
            if (Time.timeScale != 0)
            {
                gameObject.transform.Translate(Vector3.left * speed);
            }
			if (transform.position.x < -7 && countable) 
			{
				KaChow.Instance.scoreEndless++;
				countable = false;
			}
        }

    }
}