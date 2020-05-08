using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra_idle : StateMachineBehaviour
{
    public float waitTime;
    public float attackDelay;
    public float protectDelay;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Moving");
        animator.ResetTrigger("attack");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(newPos.x + ", " + newPos.y);
        if (waitTime <= 0)
        {
            animator.SetTrigger("inGround");
            waitTime = 24;
        }
        else waitTime = waitTime - Time.deltaTime;

        if (attackDelay <= 0)
        {
            animator.SetTrigger("attack");
            attackDelay = 4;
        }
        else attackDelay = attackDelay - Time.deltaTime;

        if (protectDelay <= 0)
        {
            if(!animator.gameObject.GetComponent<HydraHealth>().scream2) animator.SetTrigger("close");
            protectDelay = 5;
        }
        else protectDelay = protectDelay - Time.deltaTime;
        

    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("inGround");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
