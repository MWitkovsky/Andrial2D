using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {

    private Rigidbody2D rb;
    private float killForce = 1000.0f;
    private float rotationMin = -45.0f, rotationMax = 45.0f;
    private float minDistanceFromPlayer = 0.5f, maxDistanceFromPlayer = 3.6f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	public void Kill(float distanceFromPlayer)
    {
        gameObject.tag = Tags.corpse;
        gameObject.layer = PhysLayers.corpses;

        //Shoot the dead enemy in a random cone range downwards
        
        transform.rotation = CalculateDeathAngle(distanceFromPlayer);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(transform.up * -1.0f * killForce);        
    }

    private Quaternion CalculateDeathAngle(float distanceFromPlayer)
    {
        //(x-a)/(b-a)
        float result = Mathf.Lerp(rotationMin, rotationMax, ((distanceFromPlayer - minDistanceFromPlayer) / (maxDistanceFromPlayer - minDistanceFromPlayer)));
        return Quaternion.Euler(0.0f, 0.0f, result);
    }
}
