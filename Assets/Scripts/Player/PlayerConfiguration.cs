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

        [Header("Spline Values")] 
        public Vector3 offset;
    }
}
