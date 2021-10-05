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

    public ParticleSystem shootAnim;
    public ParticleSystem healAnim;
    public ParticleSystem defendAnim;
    public ParticleSystem stabilizeAnim;
    public ParticleSystem enemyBlood;

    private bool animSet = false;
    public Animator mc;
    public AudioSource audiSource;
    public AudioClip shootSound;
    public AudioClip healSound;
    public AudioClip stabilizeSound;
    public AudioClip defendSound;

    private void Start()
    {
        ps.defendEnd.AddListener(endDefend);

    }
    private void Update()
    {
        if(mc.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && mc.GetCurrentAnimatorStateInfo(0).IsName("MC Gunshot"))
        {
            mc.SetBool("isAttacking", false);
        }
        if(shootAnim.isEmitting)
        {
            if (shootAnim.time >= 0.8f && !animSet)
            {
                animSet = true;
                damageEvent.Invoke(ps.damage, 1);
                if (Random.Range(1, 100) <= 30)
                {
                    ps.stabilityChange(-10);
                }
                
            }
        }
        else if(shootAnim.gameObject.activeSelf && !shootAnim.isPlaying)
        {
            shootAnim.gameObject.SetActive(false);
            actionSelected.Invoke();
        }
        else if (healAnim.isEmitting)
        {
            if (healAnim.time >= 2 && !animSet)
            {
                animSet = true;
                ps.healthChange(5);
            }
        }
        else if (healAnim.gameObject.activeSelf && !healAnim.isPlaying)
        {
            healAnim.gameObject.SetActive(false);
            actionSelected.Invoke();
        }
        else if (stabilizeAnim.isEmitting)
        {
            if (stabilizeAnim.time >= 2 && !animSet)
            {
                animSet = true;
                ps.stabilityChange(50);
            }
        }
        else if (stabilizeAnim.gameObject.activeSelf && !stabilizeAnim.isPlaying)
        {
            stabilizeAnim.gameObject.SetActive(false);
            actionSelected.Invoke();
        }
        else
        {
            animSet = false;
        }
    }

    public void Shoot()
    {
        mc.SetBool("isAttacking", true);
        audiSource.PlayOneShot(shootSound);
        shootAnim.gameObject.SetActive(true);
        
    }

   public IEnumerator defendWait()
    {
        yield return new WaitForSeconds(3);
        actionSelected.Invoke();
    }

    //Fix infinite health
    public void Heal()
    {
        audiSource.PlayOneShot(healSound);
        healAnim.gameObject.SetActive(true);
    }

    public void Stabilize()
    {
        audiSource.PlayOneShot(stabilizeSound);
        stabilizeAnim.gameObject.SetActive(true);
    }

    public void Defend()
    {
        defendAnim.gameObject.SetActive(true);
        ps.defending = true;
        StartCoroutine(defendWait());
    }

    public void endDefend()
    {
        defendAnim.gameObject.SetActive(false);
    }

    


}
