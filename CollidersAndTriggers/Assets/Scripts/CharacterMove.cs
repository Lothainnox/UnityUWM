using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 3.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        // zakładamy, że komponent CharacterController jest już podpięty pod obiekt
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // zgodnie ze wzorem y = (1/2 * g) * t-kwadrat, ale jednak w trybie play
        // okazuje się, że jest to zbyt wolne opadanie, więc zastosowano g * t-kwadrat
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

