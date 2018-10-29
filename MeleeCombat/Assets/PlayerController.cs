using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    Animator weaponAnimator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponAnimator.SetBool("IsAttacking", true);
        }


	}

    public void StopAttacking()
    {
        weaponAnimator.SetBool("IsAttacking", false);

    }
}
