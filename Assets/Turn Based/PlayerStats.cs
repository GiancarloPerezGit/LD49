using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerStats : MonoBehaviour
{
    public int health;
    public int healthMax;
    public int stability;
    public int damage;

    public UnityEvent unstable;
    public UnityEvent playerDeath;
    public UnityEvent defendEnd;

    public bool defending = false;
    public void damageTaken(int damageInc)
    {
        if(defending)
        {
            damageInc /= 2;
            defending = false;
            defendEnd.Invoke();
        }
        if (health - damageInc <= 0)
        {
            health = 0;
            playerDeath.Invoke();
        }
        else
        {
            health -= damageInc;
        }
    }

    public void stabilityChange(int stabilityInc)
    {
        if(stability + stabilityInc >= 100)
        {
            stability = 100;
        }
        else if(stability + stabilityInc <= 0)
        {

            stability = 0;
            unstable.Invoke();
        }
        else
        {
            stability += stabilityInc;
        }
    }

    public void healthChange(int healthInc)
    {
        if (health + healthInc > healthMax)
        {
            health = healthMax;
        }
        else if(health + healthInc < 0)
        {
            health = 0;
        }
        else
        {
            health += healthInc;
        }
    }

    public void stabilityReset()
    {
        stability = 100;
    }
}
