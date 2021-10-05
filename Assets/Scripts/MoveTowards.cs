using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float slowModifier = 1;
    public PauseMenu pause;
    public Vector3 startLoc;
    private bool firstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        pause = GameObject.Find("Menu Controller").GetComponent<PauseMenu>();
        startLoc = this.gameObject.transform.localPosition;
    }

    private void OnEnable()
    {
        if(firstTime)
        {
            firstTime = false;
        }
        else
        {
            this.gameObject.transform.localPosition = startLoc;
        }
       
    }
    private void FixedUpdate()
    {
        if (pause.menuActive == false)
        {
            Vector3 a = transform.position;
            Vector3 b = target.position;

            transform.position = Vector3.MoveTowards(a, b, (speed / slowModifier)*Time.fixedDeltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
