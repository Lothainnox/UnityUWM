using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex5PrefabInitializer : MonoBehaviour
{
    public GameObject myPrefab;
    internal System.Random r = new System.Random();
    internal List<List<int>> positions = new List<List<int>>() { };
    internal List<int> vector;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10;)
        {
            vector = new List<int>() { r.Next(0, 11), r.Next(0, 11) };
            if (!positions.Contains(vector))
            {
                positions.Add(vector);
                i++;
            }

        }
        foreach (var vector in positions)
        {
            Instantiate(myPrefab, new Vector3(vector[0], 1, vector[1]), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
