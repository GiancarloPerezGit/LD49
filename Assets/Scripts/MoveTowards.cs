using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float slowModifier = 1;
    public PauseMenu pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("Menu Controller").GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.menuActive == false)
        {
            Vector3 a = transform.position;
            Vector3 b = target.position;

            transform.position = Vector3.MoveTowards(a, b, speed / slowModifier);
        }
        
    }
}
