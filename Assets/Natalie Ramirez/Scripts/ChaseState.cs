using UnityEngine;
using UnityEngine.AI;

namespace NatalieRoman
{
    public class ChaseState : AnnihilatorState
    {
        [SerializeField] Transform player;//player ref 
        [SerializeField] NavMeshAgent agent;//annihilator nav agent  ref

        public override void EnterState()
        {
            agent.isStopped = false;//cont movement 

            //check player ref
            if (player != null)
            {
                agent.SetDestination(player.position);//nav agent detinantoon is player position
            }
        }

        public override void UpdateState()
        {
            //check player existance and agent on navmesh 
            if (player == null || !agent.isOnNavMesh)
            {
                return;//if none 
            }

            agent.SetDestination(player.position);//update dest with current position 
        }

        public override void ExitState()
        {
            agent.isStopped = true;//stop agent movement when innactive 
        }
    }
}
