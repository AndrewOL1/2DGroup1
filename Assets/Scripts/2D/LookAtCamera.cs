using System;
using UnityEngine;

namespace _2D
{
    public class LookAtCamera : MonoBehaviour
    {
        Camera camera;
        private void Awake()
        {
            if (Camera.main != null)
            {
                camera = Camera.main;
            }
        }

        private void Update()
        {
            transform.LookAt(camera.transform.position);
        }
    }
}
