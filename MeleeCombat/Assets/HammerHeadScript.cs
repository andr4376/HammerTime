using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHeadScript : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public HammerScript hammer;
    // Use this for initialization
    void Start()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (hammer.isSwinging)
        {

            animator.SetBool("IsAttacking", false);
            hammer.isSwinging = false;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (hammer.isSwinging)
        {

            animator.SetBool("IsAttacking", false);
            hammer.isSwinging = false;
        }

    }
}
