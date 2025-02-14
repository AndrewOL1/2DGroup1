using UnityEngine;

namespace Platform
{
    public class SpawnMoveablePlatform : MonoBehaviour
    {
        [SerializeField] GameObject moveablePlatform;
        bool spawned = false;
        public void Spawn()
        {
            if (!spawned)
            {
                Instantiate(moveablePlatform, transform.position, transform.rotation);
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                spawned = true;
            }
        }
    }
}
