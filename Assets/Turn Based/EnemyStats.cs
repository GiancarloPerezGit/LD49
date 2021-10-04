using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyStats : MonoBehaviour
{
    public int health;
    public int damage;
    public UnityEvent enemyDeath;
    public void damageTaken(int damageInc)
    {
        if (health - damageInc <= 0)
        {
            health = 0;
            enemyDeath.Invoke();
        }
        else
        {
            health -= damageInc;
        }
    }
}
