using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 rotationVectorSpeed = Vector2.up;
    public Vector2 rotationVector = Vector2.up;
    public Vector3 test = Vector3.up;

    private Quaternion rotateQuad;
    void Start()
    {
        rotateQuad = Quaternion.Euler(test.x,test.y,0);
    }

    private void Rotate()
    {
        rotationVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            rotationVector = new Vector2(rotationVectorSpeed.x, rotationVector.y);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rotationVector = new Vector2(-rotationVectorSpeed.x, rotationVector.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotationVector = new Vector2(rotationVector.x, rotationVectorSpeed.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationVector = new Vector2(rotationVector.x, -rotationVectorSpeed.y);
        }

        if (rotationVector.x != 0 || rotationVector.y != 0)
        {
            rotateQuad = Quaternion.Euler(-rotationVector.x, -rotationVector.y, 0);
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