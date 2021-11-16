using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalElevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    public float distance = 14f;
    private bool isRunning = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 direction = new Vector3(0, 0, 1);

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z + distance);
    }

    void Update()
    {
        if (isRunning)
        {
            Vector3 move = direction * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
            if (transform.position.z > endPosition.z)
            {
                isRunning = false;
                direction = new Vector3(0, 0, -1);
            }

            else if (transform.position.z < startPosition.z)
            {
                isRunning = false;
                direction = new Vector3(0, 0, 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
        }
    }
}
