using Player.StateMachineScripts.States;
using UnityEngine;

namespace Player.StateMachineScripts
{
    public class StateCollection
    {
        public IdleState idleState { get; private set; }
        
        public LocomotionState locomotionState { get; private set; }
        
        public JumpState jumpState { get; private set; }

        public StateCollection(PlayerController playerController, Animator animator,PlayerConfiguration playerConfiguration)
        { 
            idleState = new IdleState(playerController, animator);
            locomotionState = new LocomotionState(playerController, animator);
            jumpState  = new JumpState(playerController, animator);
        }
    }
}