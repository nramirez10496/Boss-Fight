using UnityEngine;

namespace NatalieRoman
{
    public class AnnihilatorController : MonoBehaviour
    {
        [SerializeField] AnnihilatorState startingState;//annihilator state at start
        AnnihilatorState currentState;//current state its at 

        void Start()
        {
            currentState = startingState;//at start current state is the start state 
            currentState.EnterState();//call in enter state 
        }

        // Update is called once per frame
        void Update()
        {
            //check existance befre update 
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }

        public void ChangeState(AnnihilatorState newState)
        {
            currentState.ExitState();//call exit state for the current one and stop/clean up
            currentState = newState;//replace w/ new state
            currentState.EnterState();//start new state 
        }
    }
}
