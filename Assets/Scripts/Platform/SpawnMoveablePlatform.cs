using UnityEngine;

namespace Platform
{
    public class SpawnMoveablePlatform : MonoBehaviour
    {
        [SerializeField] GameObject moveablePlatform;

        public void Spawn()
        {
            Instantiate(moveablePlatform, transform.position, transform.rotation);
        }
    }
}
