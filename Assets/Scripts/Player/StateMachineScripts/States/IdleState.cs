using UnityEngine;

namespace Player.StateMachineScripts.States
{
    /*
     * Default State Idle
     */
    public class IdleState : BaseState
    {
        public IdleState(PlayerController player, Animator animator) : base(player, animator)
        {
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.Idle();
        }
    }
}