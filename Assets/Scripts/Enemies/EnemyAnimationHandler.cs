using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour {

    private Animator anim;
    private bool isDead;
    //trigger names
    private readonly string hitTrigger = "Hit";
    private readonly string deadTrigger = "Dead";

    // Use this for initialization
    private void Start () {
        anim = GetComponent<Animator>();
	}

    public void SetHitTrigger()
    {
        anim.SetTrigger(hitTrigger);
        isDead = true;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (isDead && col.gameObject.CompareTag(Tags.ground))
            anim.SetTrigger(deadTrigger);
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if(isDead && col.gameObject.CompareTag(Tags.ground))
            anim.SetTrigger(hitTrigger);
    }
}
