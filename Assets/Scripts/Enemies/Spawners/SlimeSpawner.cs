using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour {
    [SerializeField] private GameObject slime;
    private float spawnTime = 1.0f;
    private float spawnTimer;
	
	private void Start () {
        spawnTimer = spawnTime;
	}
	
	void Update () {
		if(spawnTimer <= 0.0f)
        {
            Instantiate(slime, transform.position, Quaternion.identity);
            spawnTimer = spawnTime;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
	}
}
