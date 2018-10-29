using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour {

    Animator animator;
    public bool isSwinging=false;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAnimationDone()
    {
        animator.SetBool("IsAttacking", false);
        isSwinging = false;
    }
    public void IsSwinging()
    {
        isSwinging = true;
    }
    public void StopSwing()
    {
        isSwinging = false;
    }
}
