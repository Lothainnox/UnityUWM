using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex6MoveWithObstacleTrigger : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Kolizja z przeszkodą");
        }
    }
}
