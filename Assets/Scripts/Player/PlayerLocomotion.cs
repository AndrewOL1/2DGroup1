using UnityEngine;

namespace Player
{
    public class PlayerLocomotion
    {
        private Rigidbody rb;
        PlayerConfiguration playerconfig;

        public PlayerLocomotion(Rigidbody rb, PlayerConfiguration playerconfig)
        {
            this.rb = rb;
            this.playerconfig = playerconfig;
        }

        public void GroundedVelocityMovement(float velocity)
        {
            Gravity(playerconfig.gravity);
            float temp = velocity*playerconfig.groundedMoveSpeed;
            Mathf.Clamp(temp,-playerconfig.maxSpeed,playerconfig.maxSpeed);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, temp);
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
        }
        #region PrivateLocomotionFucntions
        private void Gravity(float gravity)
        {
            rb.AddForce(Vector3.down * gravity);
        }
        #endregion
    }
}