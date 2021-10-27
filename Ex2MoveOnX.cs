using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2MoveOnX : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody rb;
    bool isX10 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isX10 == true)
        {
            transform.Translate(speed * -1 * Time.deltaTime, 0, 0);
            if (transform.position.x <= 0)
            {
                isX10 = false;
            }
        }
        else if (isX10 == false)
        {
        transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= 10)
            {
                isX10 = true;
            }
        }
    }
}
