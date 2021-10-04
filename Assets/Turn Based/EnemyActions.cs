using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemyDamageEvent : UnityEvent<int>
{

}

[System.Serializable]
public class EnemyStabilityEvent : UnityEvent<int>
{

}
public class EnemyActions : MonoBehaviour
{
    public EnemyStats es;
    public EnemyDamageEvent enemyDamageEvent;
    public EnemyDamageEvent enemyStabilityEvent;
    public int actionStep = 0; 
    public void actionList()
    {
        print("action");
        actionStep %= 4;
        if(actionStep == 0)
        {
            bite();
        }
        if (actionStep == 1)
        {
            spit();
        }
        if (actionStep == 2)
        {
            horrify();
        }
        else if (actionStep == 3)
        {
            regenerate();
        }
        actionStep += 1;
    }

    public void bite()
    {
        enemyDamageEvent.Invoke(es.damage);
    }
    public void spit()
    {
        enemyDamageEvent.Invoke(es.damage/2);
    }
    public void horrify()
    {
        enemyStabilityEvent.Invoke(-25);
    }
    public void regenerate()
    {
        es.damageTaken(-4);
    }
}
