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

        public override void OnEnter()
        {
            if(player.Bird)
                animator.CrossFade(BirdIdleHash,crossFadeDuration);
            else
                animator.CrossFade(IdleHash,crossFadeDuration);
        }

        public override void FixedUpdate()
        {
            player.PlayerLocomotion.Idle();
        }
        
    }
}