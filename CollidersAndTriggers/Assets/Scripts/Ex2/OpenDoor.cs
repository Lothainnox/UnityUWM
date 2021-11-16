using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float doorSpeed = 3f;
    public float distance = -3f;
    public bool isOpening = false;
    public bool isMoving = false;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 direction = new Vector3(0, 0, -1);

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z + distance);
    }

    void Update()
    {
        if (isMoving)
        {
            if (isOpening)
            {
                if (transform.position.z <= endPosition.z)
                {
                    isMoving = false;
                    isOpening = false;
                    direction = new Vector3(0, 0, 1);
                }
                else
                {
                    Vector3 move = direction * doorSpeed * Time.deltaTime;
                    transform.Translate(move);
                }
            }
            else
            {
                if (transform.position.z >= startPosition.z)
                {
                    isMoving = false;
                    isOpening = true;
                    direction = new Vector3(0, 0, -1);
                }
                else
                {
                    Vector3 move = direction * doorSpeed * Time.deltaTime;
                    transform.Translate(move);
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi się otwierają");
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi się zamykają");
            isMoving = true;
        }
    }
}
