using Dreamteck.Splines;
using UnityEngine;

namespace Player
{
    /*
     * Store all const varibles for the player
     */
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerConfiguration : ScriptableObject
    {
        [Header("Movement Values")]
        public float groundedMoveSpeed;
        public float maxSpeed;
        public float gravity;
        
        [Header("Jump Values")]
        public float jumpForce;
        public float maxJumpTime;
        public float coyoteTime;
        
        [Header("Interaction Values")]
        public GameObject interactionObject;
        [Header("lastCheckpoint")]
        public Vector3 lastCheckpoint;
        public float RespawnTime;
        public bool IsDead;
    }
}
