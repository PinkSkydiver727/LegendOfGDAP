using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantPunchBehaviour : StateMachineBehaviour {

    public Transform player;
    public isHurtBox.hurtType hurtType;
    public float moveDuringAttack;
    GameObject self;
    NavMeshAgent nav;
    isHurtBox hurtBox;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.GetComponent<GameObjectData>().data.transform;
        self = animator.gameObject;
        nav = self.GetComponent<NavMeshAgent>();
        Vector3 pos = self.transform.position;
        Vector3 dir = (player.position - pos).normalized * moveDuringAttack; // Direction to player with distance 1
        nav.SetDestination(self.transform.position + dir);

        isHurtBox[] hurtSlots = self.GetComponentsInChildren<isHurtBox>();

        foreach (isHurtBox ishurt in hurtSlots)
        {
            // slot type matches
            if (ishurt.slotType == hurtType)
            {
                // turn off active weapon
                if (ishurt.hurtBox != null)
                {
                    //hurtBox = ishurt.hurtBox;
                    hurtBox = ishurt;
                    hurtBox.active = true;
                }
            }
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
//        if(player.gameObject.GetComponent<>().data <= 0)
  //      {
    //        animator.SetTrigger("taunt");
      //  }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hurtBox.active = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
