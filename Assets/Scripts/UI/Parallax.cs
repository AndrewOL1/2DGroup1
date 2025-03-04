using System;
using UnityEngine;

namespace Ui
{
    public class Parallax : MonoBehaviour
    {
        private float xPosition, sizeX;
        Camera mainCamera;
        [SerializeField]float ParallaxSpeed;
        void Start()
        {
            mainCamera = Camera.main;
            sizeX=GetComponent<SpriteRenderer>().bounds.size.x;
            xPosition = transform.position.x;
        }

        private void FixedUpdate()
        {
            float displacement = mainCamera.transform.position.x *(1-ParallaxSpeed);
            transform.position = new Vector3(xPosition + (mainCamera.transform.position.x * ParallaxSpeed)+sizeX,transform.position.y,transform.position.z);

           if (displacement > xPosition + sizeX)
                xPosition += sizeX;
            if (displacement < xPosition + sizeX)
                xPosition -= sizeX;
        }
    }
}
