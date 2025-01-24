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
        //Spline
        private  SplineComputer groundSpline; 
        private Vector3 nextSplinePoint;
        private Vector3 lastSplinePoint;
        private int splinePointCount;
        private int totalSplinePointCount;
        private bool rightDirection=true;
        
        #endregion
        public PlayerLocomotion(Rigidbody rb, PlayerConfiguration playerconfig,SplineComputer groundSpline)
        {
            this.rb = rb;
            this.playerconfig = playerconfig;
            this.groundSpline = groundSpline;
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
            Vector2 normal;
            float temp = velocityInput*playerconfig.groundedMoveSpeed;
            Mathf.Clamp(temp,-playerconfig.maxSpeed,playerconfig.maxSpeed);
            if (temp > 0)
            { 
                normal=new Vector2(nextSplinePoint.x, nextSplinePoint.z)-new Vector2(rb.transform.position.x, rb.transform.position.z); 
                rightDirection = true;
            }
            else if (temp < 0)
            {
                normal=new Vector2(rb.transform.position.x, rb.transform.position.z)-new Vector2(lastSplinePoint.x, lastSplinePoint.z);
                rightDirection=false;
            }
            else
            {
                normal=Vector2.zero;
            }
            normal.Normalize();
            rb.velocity = new Vector3(normal.x*temp, rb.velocity.y, normal.y*temp);
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

        public void UpdatePositionTargets(int next)
        {
            splinePointCount=next;
            if (splinePointCount == totalSplinePointCount || totalSplinePointCount == 0)
                return;
            if (rightDirection)
            {
                lastSplinePoint = groundSpline.GetPointPosition(next);
                nextSplinePoint = groundSpline.GetPointPosition(next + 1);
            }
            else
            {
                lastSplinePoint = groundSpline.GetPointPosition(next-1);
                nextSplinePoint = groundSpline.GetPointPosition(next);
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