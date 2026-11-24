using UnityEngine;

namespace NatalieRoman
{
    public abstract class AnnihilatorState : MonoBehaviour
    {
        //different for each state 
        public abstract void EnterState();//called when x state becomes active
        public abstract void UpdateState();//called every frame x state is active
        public abstract void ExitState();//called when x state becomes inactive

    }
}
