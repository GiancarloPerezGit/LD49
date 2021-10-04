using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDestroyer : MonoBehaviour
{
    public SpawnMovable spawner;
    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Moveable")
        {
            Destroy(other.gameObject);
            triggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}
