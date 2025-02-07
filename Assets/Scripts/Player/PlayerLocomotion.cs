using Dreamteck.Splines;
using Dreamteck.Splines.Editor;
using Platform;
using UnityEngine;

namespace Player
{
    public class PlayerLocomotion
    {
        /*
         * The goal is Handle all movement related actions for the player
         */
        #region Variables
        private Rigidbody rb;
        PlayerConfiguration playerconfig; 
        private bool rightDirection=true;
        //interact
        public DialogueTrigger interactingObject;
        
        #endregion
        public PlayerLocomotion(Rigidbody rb, PlayerConfiguration playerconfig)
        {
            this.rb = rb;
            this.playerconfig = playerconfig;
        }

        public void GroundedVelocityMovement(float velocityInput)
        {
            Gravity(playerconfig.gravity);
                //rb.MovePosition(new Vector3(rb.position.x+(velocityInput*playerconfig.groundedMoveSpeed), rb.position.y,0));
                rb.velocity = new Vector3(velocityInput*playerconfig.groundedMoveSpeed, rb.velocity.y,0);
                if(velocityInput>0)
                    rightDirection = true;
                else if(velocityInput<0)
                    rightDirection = false;
        }

        public void JumpingVelocityMovement(float startTime)
        {
            float timeJumpWasHeld = Time.time - startTime;
            if (timeJumpWasHeld > playerconfig.maxJumpTime)
                timeJumpWasHeld = playerconfig.maxJumpTime;
            rb.AddForce(0,timeJumpWasHeld*playerconfig.jumpForce,0,ForceMode.Impulse);
        }
        public void Idle()
        {
            Gravity(playerconfig.gravity);
            //rb.MovePosition(new Vector3(rb.position.x,rb.position.y,0));
            rb.velocity=new Vector3(0,rb.velocity.y,0);
        }

        public void ZeroVelocity()
        {
            rb.velocity= Vector3.zero;
        }
        //Dialogue
        public void StartDialogue()
        {
            interactingObject.TriggerDialogue();
            if (interactingObject.GetComponent<SpawnMoveablePlatform>() != null)
            {
                interactingObject.GetComponent<SpawnMoveablePlatform>().Spawn();
            }
        }

        public void DialogueUpdate(bool newDialogue)
        {
            if (newDialogue)
            {
                DialogueManager.instance.DisplayNextDialogueLine();
            }
        }
        #region PrivateLocomotionFucntions
        private void Gravity(float gravity)
        {
            rb.AddForce(Vector3.down * gravity);
        }
        #endregion
    }
}