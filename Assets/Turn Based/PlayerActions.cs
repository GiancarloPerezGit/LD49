using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DamageEvent : UnityEvent<int, int>
{

}

[System.Serializable]
public class AnimationEvent : UnityEvent<float>
{

}
public class PlayerActions : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats ps;
    public int unlockedActionsCount = 2;
    public UnityEvent actionSelected;
    public DamageEvent damageEvent;
    public AnimationEvent animEvent;
    public bool locked = true;
    private void Update()
    {
        
    }

    public void Shoot()
    {
        damageEvent.Invoke(ps.damage, 1);
      
        if(Random.Range(1, 100) <= 30)
        {
            ps.stabilityChange(-10);
        }
        actionSelected.Invoke();
    }

    //Fix infinite health
    public void Heal()
    {
        ps.healthChange(5);
        actionSelected.Invoke();
    }

    public void Stabilize()
    {
        ps.stabilityChange(50);
        actionSelected.Invoke();
    }

    public void Defend()
    {
        ps.defending = true;
        actionSelected.Invoke();
    }




}
