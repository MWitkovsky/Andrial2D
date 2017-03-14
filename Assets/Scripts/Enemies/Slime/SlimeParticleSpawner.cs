using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeParticleSpawner : MonoBehaviour {

    [SerializeField] private GameObject slimeParticle;

    private float particleForce = 400.0f;
    private int particlesToSpawn = 10;

	public void SpawnSlimeParticles()
    {
        Vector2 velocityVector = Vector2.zero;
        while(particlesToSpawn > 0)
        {
            //Get a random direction
            velocityVector.x = Random.Range(-0.5f, 0.5f);
            velocityVector.y = Random.Range(0.5f, 1.0f);

            //Spawn particle and apply it
            GameObject particle = Instantiate(slimeParticle, transform.position, Quaternion.identity, transform);
            particle.GetComponent<Rigidbody2D>().AddForce(velocityVector.normalized * particleForce);
            --particlesToSpawn;
        }
    }
}
