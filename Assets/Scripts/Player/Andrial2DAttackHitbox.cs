using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrial2DAttackHitbox : MonoBehaviour {

    private Andrial2DRunnerController player;

    private void Start()
    {
        player = FindObjectOfType<Andrial2DRunnerController>();
    }

	private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(Tags.enemy))
        {
            other.GetComponent<EnemyHandler>().Kill(Vector3.Distance(player.transform.position, other.transform.position));
            player.HitEnemy();
        }
    }
}
