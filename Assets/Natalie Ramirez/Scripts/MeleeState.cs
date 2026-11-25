using UnityEngine;
using UnityEngine.AI;

namespace NatalieRoman
{
    public class MeleeState : AnnihilatorState
    {
        [SerializeField] NavMeshAgent agent;//annihilator nav agent  ref
        [SerializeField] Animator animator;//animator ref
        [SerializeField] AnnihilatorController controller;//controller ref 
        [SerializeField] ChaseState chaseState;
        [SerializeField] float attackDuration = 1f;//how long attack is 
        [SerializeField] string punchTrigger = "Punch";//trigger animation
        float attackTimer;//timer for attack 
        [SerializeField] Transform player;//player transform ref

        public override void EnterState()
        {
            agent.isStopped = true;//stop to perform attack 
            FacePlayer();//turn towards player
            attackTimer = attackDuration;//begin attack timer
            animator.SetTrigger(punchTrigger);//trigger animation 
        }

        public override void UpdateState()
        {
            attackTimer -= Time.deltaTime;//count down till attacks done

            //if timer reaches 0
            if (attackTimer <= 0f)
            {
                controller.ChangeState(chaseState);//chase player 
            }
        }

        public override void ExitState()
        {
            animator.ResetTrigger(punchTrigger);//reset trigger 
        }

        void FacePlayer()
        {
            //no plyer
            if (player == null)
            {
                return;
            }
            Vector3 direction = player.position - transform.position;//direction towards plauer 

            direction.y = 0f;//not vertical

            //if not 0 turn boss to player
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
