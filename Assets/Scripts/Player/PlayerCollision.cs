using System;
using Spline;
using Unity.VisualScripting;
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
        
        [Header("Directional")]
        [SerializeField] LayerMask objectLayer;
        [SerializeField] float directionDistance;
        [SerializeField] bool directionGizmoz;
        
        
        public int nextPosition;
        public bool InIteractable;
        PlayerLocomotion playerLocomotion;

        public void setPlayerLocomotion(PlayerLocomotion playerLocomotion)
        {
            this.playerLocomotion = playerLocomotion;
        }
        public bool Ground => Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundLayer);
        public bool CantForward => Physics.Raycast(groundCheck.position, groundCheck.forward, directionDistance, objectLayer);
        private void OnDrawGizmos()
        {
            if (groundGizmoz)
            {
                if (Ground) { Gizmos.color = Color.green; }
                else { Gizmos.color = Color.red; }

                Gizmos.DrawRay(groundCheck.position, Vector3.down * groundDistance);
            }

            if (directionGizmoz)
            {
                if (CantForward)
                {
                    Gizmos.color = Color.green;
                }
                else
                {
                    Gizmos.color = Color.red; 
                }
                Gizmos.DrawRay(groundCheck.position, groundCheck.forward * directionDistance);
            }
        }

        public void FixedUpdate()
        {
            playerLocomotion.canMoveForward = !CantForward;
        }
        private void OnTriggerEnter(Collider other)
        {
            /*
            if (other.CompareTag("Spline"))
            {
                playerLocomotion.UpdatePositionTargets(other.GetComponent<SplineTrigger>().positionNumber);
            }
            */
            if (other.CompareTag("Interactable"))
            {
                InIteractable = true;
                playerLocomotion.interactingObject=other.GetComponent<DialogueTrigger>();
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                InIteractable = false;
                playerLocomotion.interactingObject = null;
            }
        }
    }
}