using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex3MoveOnSquare : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody rb;
    bool isX10 = false;
    bool isZ10 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (isX10 == false && isZ10 == false && transform.position.x >= 10)
        {
            this.transform.Rotate(0, -90, 0, Space.Self);
            isX10 = true;
        }
        else if (isX10 == true && isZ10 == false && transform.position.z >= 10)
        {
            this.transform.Rotate(0, -90, 0, Space.Self);
            isZ10 = true;
        }
        else if (isX10 == true && isZ10 == true && transform.position.x <= 0)
        {
            this.transform.Rotate(0, -90, 0, Space.Self);
            isX10 = false;
        }
        else if  (isX10 == false && isZ10 == true && transform.position.z <= 0)
        {
            this.transform.Rotate(0, -90, 0, Space.Self);
            isZ10 = false;
        }
    }
}


// Rozbuduj skrypt z zadania 2 (ale zapisz wszystko w nowym skrypcie), 
// tak aby obiekt poruszał się 'po kwadracie' o boku 10 jednostek i docierając 
// do wierzchołka wykonywał obrót o 90 stopni w kierunku kolejnego wierzchołka.