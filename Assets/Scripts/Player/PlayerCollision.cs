using System;
using Spline;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [Header("GROUND/Fall")]
        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float groundDistance;
        [SerializeField] bool groundGizmoz;
        [SerializeField] PlayerController player;
        public int nextPosition;
        PlayerLocomotion playerLocomotion;

        public void setPlayerLocomotion(PlayerLocomotion playerLocomotion)
        {
            this.playerLocomotion = playerLocomotion;
        }
        public bool Ground => Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);
        
        private void OnDrawGizmos()
        {
            if (groundGizmoz)
            {
                if (Ground) { Gizmos.color = Color.green; }
                else { Gizmos.color = Color.red; }

                Gizmos.DrawRay(groundCheck.position, Vector3.down * groundDistance);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Spline"))
            {
                playerLocomotion.UpdatePositionTargets(other.GetComponent<SplineTrigger>().positionNumber);
            }
        }
    }
}