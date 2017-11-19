using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endlessMonkey
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] spawnList;
        public GameObject basepos, parentObst;
        private float[] spawnFrequency, spawnRange;
        private float totalFrequency;
        // Use this for initialization	
        private float lastSpawnTime;
        void Start()
		{
            int types = spawnList.Length;
            spawnFrequency = new float[types];
            spawnRange = new float[types];
            for (int i = 0; i < types; i++)
            {
                spawnFrequency[i] = spawnList[i].GetComponent<Obstacle>().spawnFrequency;
                totalFrequency += spawnFrequency[i];
                spawnRange[i] = totalFrequency;
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - lastSpawnTime > 2.5f)
            {
                Spawn();
                lastSpawnTime = Time.time;
            }
        }
        void Spawn()
        {
            float rand = Random.Range(0, totalFrequency);
            for (int i = 0; i < spawnList.Length; i++)
            {
                if (rand < spawnRange[i])
                {
                    Vector2 instpos = basepos.transform.position;
                    instpos = new Vector2(instpos.x, instpos.y + basepos.transform.localScale.y + spawnList[i].transform.localScale.y);
                    GameObject thisObstacle = Instantiate(spawnList[i], instpos, Quaternion.identity);
					thisObstacle.transform.SetParent (parentObst.transform);
					Destroy (thisObstacle, 5);
                    break;
                }
            }
        }
    }
}