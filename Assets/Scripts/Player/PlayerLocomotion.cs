using Dreamteck.Splines;
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
        private SplineFollower follower;
        //Spline
        private  SplineComputer groundSpline; 
        private Vector3 nextSplinePoint;
        private Vector3 lastSplinePoint;
        private int splinePointCount;
        private int totalSplinePointCount;
        private bool rightDirection=true;
        public bool canMoveForward=true;
        //interact
        public DialogueTrigger interactingObject;
        
        #endregion
        public PlayerLocomotion(Rigidbody rb, PlayerConfiguration playerconfig,SplineComputer groundSpline)
        {
            this.rb = rb;
            this.playerconfig = playerconfig;
            this.groundSpline = groundSpline;
            follower = rb.GetComponent<SplineFollower>();
            StartPos();
        }

        public void StartPos()
        {
            
            rb.transform.position = groundSpline.GetPointPosition(0)+playerconfig.offset;
            lastSplinePoint= groundSpline.GetPointPosition(0);
            nextSplinePoint= groundSpline.GetPointPosition(1);
            splinePointCount = 0;
            totalSplinePointCount=groundSpline.pointCount-1;
        }
        public void GroundedVelocityMovement(float velocityInput)
        {
            Gravity(playerconfig.gravity);
            if (canMoveForward)
            {
                float temp = velocityInput * playerconfig.groundedMoveSpeed;
                temp = Mathf.Clamp(temp, -playerconfig.maxSpeed, playerconfig.maxSpeed);
                if (temp > 0)
                {
                    rightDirection = true;
                }
                else if (temp < 0)
                {
                    rightDirection = false;
                }

                follower.followSpeed = temp;
            }
            else
            {
                if (rightDirection)
                {
                    if (velocityInput > 0)
                    {
                        float temp = velocityInput * playerconfig.groundedMoveSpeed;
                        temp = Mathf.Clamp(temp, -playerconfig.maxSpeed, playerconfig.maxSpeed);
                        rightDirection = false;
                        follower.followSpeed = temp;
                    }
                    else
                    {
                        follower.followSpeed = 0;
                    }

                }
                else
                {
                    if (velocityInput < 0)
                    {
                        float temp = velocityInput * playerconfig.groundedMoveSpeed;
                        temp = Mathf.Clamp(temp, -playerconfig.maxSpeed, playerconfig.maxSpeed);
                        rightDirection = true;
                        follower.followSpeed = temp;
                    }
                    else
                    {
                        follower.followSpeed = 0;
                    }
                }
            }
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
            follower.followSpeed = 0;
        }

        public void StartDialogue()
        {
            interactingObject.TriggerDialogue();
        }
        #region PrivateLocomotionFucntions
        private void Gravity(float gravity)
        {
            rb.AddForce(Vector3.down * gravity);
        }
        #endregion
    }
}