using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex4RestrictedLookAround : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;

    private float mouseYDesiredPosition = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYDesiredPosition += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXMove);

        float mouseYNewPosition = mouseYDesiredPosition > 90 ? 90 : mouseYDesiredPosition < -90 ? -90 : mouseYDesiredPosition;
        transform.localRotation = Quaternion.Euler(-mouseYNewPosition, 0f, 0f);
    }
}
