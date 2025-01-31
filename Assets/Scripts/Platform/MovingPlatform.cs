using System;
using UnityEngine;

namespace Platform
{
    public class MovingPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                other.transform.parent = transform;
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player"))
                other.transform.parent = null;
        }
    }
}
