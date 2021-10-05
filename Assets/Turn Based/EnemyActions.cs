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
    public UnityEvent enemyDone;

    public EnemyStats es;
    public EnemyDamageEvent enemyDamageEvent;
    public EnemyDamageEvent enemyStabilityEvent;

    public ParticleSystem fireAnim;
    public ParticleSystem spitAnim;
    public ParticleSystem horrifyAnim;
    public ParticleSystem regenAnim;
    private bool animSet = false;
    public int actionStep = 0;
    public AudioSource audiSource;
    public AudioClip fireSound;
    public AudioClip spitSound;
    public AudioClip horrifySound;
    public AudioClip regenSound;
    public float animTiming;
    private void Update()
    {
        if (fireAnim.isEmitting)
        {
            if (fireAnim.time >= 1.1f && !animSet)
            {
                animSet = true;
                enemyDamageEvent.Invoke(es.damage);
            }
        }
        else if (fireAnim.gameObject.activeSelf && !fireAnim.isPlaying)
        {
            fireAnim.gameObject.SetActive(false);
            enemyDone.Invoke();
        }
        else if (spitAnim.isEmitting)
        {
            if (spitAnim.time >= 2.5f && !animSet)
            {
                animSet = true;
                enemyDamageEvent.Invoke(es.damage/2);
            }
        }
        else if (spitAnim.gameObject.activeSelf && !spitAnim.isPlaying)
        {
            spitAnim.gameObject.SetActive(false);
            enemyDone.Invoke();
        }
        else if (horrifyAnim.isEmitting)
        {
            if (horrifyAnim.time >= 0.5f && !animSet)
            {
                animSet = true;
                enemyStabilityEvent.Invoke(-25);
            }
        }
        else if (horrifyAnim.gameObject.activeSelf && !horrifyAnim.isPlaying)
        {
            horrifyAnim.gameObject.SetActive(false);
            enemyDone.Invoke();
        }
        else if (regenAnim.isEmitting)
        {
            if (regenAnim.time >= 0.5f && !animSet)
            {
                animSet = true;
                es.damageTaken(-4);
            }
        }
        else if (regenAnim.gameObject.activeSelf && !regenAnim.isPlaying)
        {
            regenAnim.gameObject.SetActive(false);
            enemyDone.Invoke();
        }
        else
        {
            animSet = false;
        }
    }
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
    IEnumerator soundWait()
    {
        yield return new WaitForSeconds(1);
        fireAnim.gameObject.SetActive(true);
    }
    public void bite()
    {
        audiSource.PlayOneShot(fireSound);
        StartCoroutine(soundWait());
        
    }
    public void spit()
    {
        audiSource.PlayOneShot(spitSound);
        spitAnim.gameObject.SetActive(true);
    }
    public void horrify()
    {
        audiSource.PlayOneShot(horrifySound);
        horrifyAnim.gameObject.SetActive(true);
    }
    public void regenerate()
    {
        audiSource.PlayOneShot(regenSound);
        regenAnim.gameObject.SetActive(true);
    }
}
