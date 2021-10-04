using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovable : MonoBehaviour
{

    public bool canSpawn = false;
    public GameObject prefab;
    public TargetType moveTarget;
    public float moveSpeed = 1;
    public float slowMod = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            Spawn(prefab, moveTarget, moveSpeed, slowMod);
            canSpawn = false;
        }
    }

    public void Spawn(GameObject pf, TargetType targetType, float speed, float slow)
    {
        GameObject target = CheckTarget(targetType);

        GameObject spawn = GameObject.Instantiate(pf, transform.position, Quaternion.identity);
        spawn.GetComponent<MoveTowards>().target = target.transform;
        spawn.GetComponent<MoveTowards>().speed = speed;
        spawn.GetComponent<MoveTowards>().slowModifier = slow;
    }

    public GameObject CheckTarget(TargetType tt)
    {
        GameObject target = null;
        //for particles
        if (tt == TargetType.PLAYER)
        {
            target = GameObject.Find("MC Target");
        }
        else if (tt == TargetType.ENEMY)
        {
            target = GameObject.Find("Enemy Target");
        }
        //for planets
        else if (tt == TargetType.BROKEN)
        {
            target = GameObject.Find("Broken Target");
        }
        else if (tt == TargetType.BROWN)
        {
            target = GameObject.Find("Brown Target");
        }
        else if (tt == TargetType.GREEN)
        {
            target = GameObject.Find("Green Target");
        }
        else if (tt == TargetType.PURPLE)
        {
            target = GameObject.Find("Purple Target");
        }
        else if (tt == TargetType.STATION)
        {
            target = GameObject.Find("Station Target");
        }
        return target;
    }
}
