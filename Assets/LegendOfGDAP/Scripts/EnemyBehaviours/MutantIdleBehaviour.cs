using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MutantIdleBehaviour : StateMachineBehaviour {

    public Transform player;
    GameObject self;
    NavMeshAgent nav;
    public float attackCooldown;
    float time;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.GetComponent<GameObjectData>().data.transform;
        self = animator.gameObject;
        nav = self.GetComponent<NavMeshAgent>();
        time = 0.0f;
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.deltaTime;
        if (time > attackCooldown)
        {
            Vector3 pos = self.transform.position;
            Vector3 dir = (player.position - pos).normalized;
            pos.y += 1;
            Debug.DrawLine(pos, pos + dir * 10, Color.red, Mathf.Infinity);

            RaycastHit hit = new RaycastHit();


            Ray ray = new Ray(pos, dir);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<isPlayer>())
                {
                    nav.SetDestination(player.position);
                    float speed = Vector3.Project(nav.desiredVelocity, self.transform.forward).magnitude;
                    animator.SetFloat("speed", speed);
                    //Debug.Log(speed);
                }
            }
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
