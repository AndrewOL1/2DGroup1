using Player.StateMachineScripts.States;
using UnityEngine;

namespace Player.StateMachineScripts
{
    public class StateCollection
    {
        public IdleState IdleState { get; private set; }
        
        public LocomotionState LocomotionState { get; private set; }
        
        public JumpState JumpState { get; private set; }
        public DialogueState DialogueState { get; private set; }
        public RespawningState RespawnState { get; private set; }

        public StateCollection(PlayerController playerController, Animator animator,PlayerConfiguration playerConfiguration)
        { 
            IdleState = new IdleState(playerController, animator);
            LocomotionState = new LocomotionState(playerController, animator);
            JumpState  = new JumpState(playerController, animator);
            DialogueState = new DialogueState(playerController, animator);
            RespawnState = new RespawningState(playerController,animator);
        }
    }
}