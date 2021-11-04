using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    internal System.Random r = new System.Random();
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int count = 10;
    public GameObject block;
    public Material[] materials;
    void Start()
    {
        Vector3 rawPlaneSize = GetComponent<MeshRenderer>().bounds.size;

        // List<int> pozycje_x = new List<int>(Enumerable.Range(0, 2 * count).OrderBy(x => Guid.NewGuid()).Take(count));
        // List<int> pozycje_z = new List<int>(Enumerable.Range(0, 2 * count).OrderBy(x => Guid.NewGuid()).Take(count));

        for (int i = 0; i < count; i++)
        {
            int x = r.Next((int)(-rawPlaneSize.x / 2 + transform.position.x), (int)(rawPlaneSize.x / 2 + transform.position.x));
            int z = r.Next((int)(-rawPlaneSize.z / 2 + transform.position.z), (int)(rawPlaneSize.z / 2 + transform.position.z));
            this.positions.Add(new Vector3(x, 5, z));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            int i = r.Next(0, materials.Count());
            this.block.GetComponent<MeshRenderer>().material = materials[i];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}

