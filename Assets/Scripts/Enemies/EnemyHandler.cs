using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private bool isGroundEnemy;

    private EnemyAnimationHandler anim;
    private Rigidbody2D rb;
    private float killForce = 1000.0f;
    private float rotationMin = -45.0f, rotationMax = 45.0f;
    private float minDistanceFromPlayer = 0.5f, maxDistanceFromPlayer = 3.6f;
    private float despawnTimer = 4.0f;
    private bool isDead;

    private void Start()
    {
        anim = GetComponent<EnemyAnimationHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead)
        {
            despawnTimer -= Time.deltaTime;
            if (despawnTimer <= 0.0f)
                Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.fixedDeltaTime, Space.World);
    }

	public void Kill(float distanceFromPlayer)
    {
        gameObject.tag = Tags.corpse;
        gameObject.layer = PhysLayers.corpses;

        //Shoot the dead enemy in a random cone range downwards
        transform.rotation = CalculateDeathAngle(distanceFromPlayer);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce(transform.up * -1.0f * killForce);
        transform.rotation = Quaternion.Euler(Vector3.zero);

        //Set flags
        anim.SetHitTrigger();
        isDead = true;
    }

    private Quaternion CalculateDeathAngle(float distanceFromPlayer)
    {
        //(x-a)/(b-a) == % x is from a to b
        float result = Mathf.Lerp(rotationMin, rotationMax, ((distanceFromPlayer - minDistanceFromPlayer) / (maxDistanceFromPlayer - minDistanceFromPlayer)));
        return Quaternion.Euler(0.0f, 0.0f, result);
    }

    public bool IsGroundEnemy()
    {
        return isGroundEnemy;
    }
}
