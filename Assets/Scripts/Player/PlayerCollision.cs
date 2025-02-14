using System;
using Platform;
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
        
        public float coyoteTimer;
        public bool InIteractable;
        PlayerLocomotion playerLocomotion;

        public void SetPlayerLocomotion(PlayerLocomotion playerLocomotion)
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
            if (other.CompareTag("Interactable"))
            {
                InIteractable = true;
                playerLocomotion.interactingObject=other.GetComponent<DialogueTrigger>();
                if (other.name == "Dialogue Trigger_2")
                {
                    other.GetComponent<AddBird>().Spawn();
                }
                if (other.name == "Dialogue Trigger_4")
                {
                    other.GetComponent<SpawnMoveablePlatform>().Spawn();
                }
                if (other.name == "Dialogue Trigger_5")
                {
                    other.GetComponent<End>().GameEnd();
                }
            }
            if(other.CompareTag("Checkpoint"))
                player.playerData.lastCheckpoint = other.transform.position;
            if (other.CompareTag("Death"))
                player.playerData.IsDead = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Interactable"))
            {
                InIteractable = false;
                playerLocomotion.interactingObject = null;
            }
        }

        public void Update()
        {
            if (Ground)
            {
                coyoteTimer=player.playerData.coyoteTime;
            }
            else
            {
                coyoteTimer-=Time.deltaTime;
            }
        }
    }
}