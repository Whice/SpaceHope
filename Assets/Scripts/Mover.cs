using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceHope.View.Components
{
    public class Mover : MonoBehaviour
    {
        public float speed = 2f;
        public Vector2 rotationVectorSpeed = Vector2.up;
        public Vector2 rotationVector = Vector2.up;
        public Vector3 test = Vector3.up;

        private Quaternion rotateQuad;
        public Vector2 rotateAxis = Vector2.zero;

        private void Rotate()
        {
            rotationVector = new Vector2(rotateAxis.x * rotationVectorSpeed.x, rotateAxis.y * rotationVectorSpeed.y);
            if (rotationVector.x != 0 || rotationVector.y != 0)
            {
                rotateQuad = Quaternion.Euler(rotationVector.x, rotationVector.y, 0);
                transform.rotation *= rotateQuad;
            }
        }
        void Update()
        {
            Rotate();

            Vector3 currentPosition = transform.localPosition;
            Vector3 direction = transform.forward;
            float currentSpeed = speed * Time.deltaTime;
            transform.localPosition = new Vector3
                (
                currentPosition.x + direction.x * currentSpeed,
                currentPosition.y + direction.y * currentSpeed,
                currentPosition.z + direction.z * currentSpeed
                );
        }
    }
}