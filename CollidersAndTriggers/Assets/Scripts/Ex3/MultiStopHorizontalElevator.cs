using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiStopHorizontalElevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private bool isHeadingEnd = true;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public List<Vector3> stopPositions;
    private int currentHeadingPlatformIndex = 0;


    void Start()
    {
        startPosition = transform.position;
        endPosition = stopPositions.Last();
    }

    void Update()
    {
        if (isRunning && isHeadingEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, stopPositions[currentHeadingPlatformIndex], elevatorSpeed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                isRunning = false;
                isHeadingEnd = false;
            }
            else if (transform.position == stopPositions[currentHeadingPlatformIndex])
            {
                currentHeadingPlatformIndex++;
            }
        }
        else if (isRunning && !isHeadingEnd && currentHeadingPlatformIndex == -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, elevatorSpeed * Time.deltaTime);

            if (transform.position == startPosition)
            {
                isRunning = false;
                isHeadingEnd = true;
                currentHeadingPlatformIndex = 0;
            }
        }
        else if (isRunning && !isHeadingEnd && currentHeadingPlatformIndex >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, stopPositions[currentHeadingPlatformIndex], elevatorSpeed * Time.deltaTime);
            
            if (transform.position == stopPositions[currentHeadingPlatformIndex])
            {
                currentHeadingPlatformIndex--;
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
            isRunning = false;
        }
    }
}
