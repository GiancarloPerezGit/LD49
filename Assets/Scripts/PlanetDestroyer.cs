using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDestroyer : MonoBehaviour
{
    public Transform spawner;
    public Transform moveable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveable.transform.position == transform.position)
        {
            moveable.transform.position = spawner.transform.position;
        }
    }
}
