using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class TBController : MonoBehaviour
{
    public PlayerActions pa;
    public PlayerStats ps;
    public EnemyActions ea;
    public EnemyStats es;
    public ActionSelection actSelect;
    public int turn = 0;

    public ActionSelection UIController;
    public GameObject endScreen;
    public GameObject win;
    public GameObject lose;
    private bool playerEnd = false;
    private bool enemyWait = false;
    private bool enemyEnd = false;
    private bool stopTurns = false;
    private bool turnStart = true;

    private bool unstable = false;
    private int unstableCounter = 0;

    public bool animationWait = false;

    public ParticleSystem stunEffect;
    // Start is called before the first frame update
    void Start()
    {
        pa.actionSelected.AddListener(SwapTurns);
        ps.unstable.AddListener(Instability);
        pa.damageEvent.AddListener(EnemyDamage);
        ea.enemyDamageEvent.AddListener(PlayerDamage);
        ea.enemyStabilityEvent.AddListener(PlayerStabilityDamage);
        ps.playerDeath.AddListener(Loss);
        es.enemyDeath.AddListener(Victory);
        ea.enemyDone.AddListener(EnemyActionDone);
    }

    public void SwapTurns()
    {
        playerEnd = true;
    }

    public void Instability()
    {
        if(unstable)
        {

        }
        else
        {
            stunEffect.gameObject.SetActive(true);
            unstable = true;
            unstableCounter = 3;
        }
        
    }

    public void EnemyDamage(int dam, int target)
    {
        es.damageTaken(dam);
    }

    public void PlayerDamage(int dam)
    {
        ps.damageTaken(dam);
    }
    public void PlayerStabilityDamage(int dam)
    {
        ps.stabilityChange(dam);
    }

    public void Victory()
    {
        
        actSelect.enabled = false;
        endScreen.SetActive(true);
        win.SetActive(true);
    }
    public void Loss()
    {
        actSelect.enabled = false;
        endScreen.SetActive(true);
        lose.SetActive(true);
    }

    public void EnemyActionDone()
    {
        enemyEnd = true;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
        if(!animationWait)
        {
            if (!stopTurns)
            {
                turnCheck();
            }
        }
        
        
    }

    public void playerTurnStart()
    {
        if(unstable)
        {
            if(unstableCounter != 0)
            {
                unstableCounter -= 1;
                
                playerEnd = true;
            }
            else
            {
                stunEffect.gameObject.SetActive(false);
                unstable = false;
                ps.stabilityReset();
                UIController.locked = false;
            }
        }
        else
        {
            UIController.locked = false;
        }
        
    }

    public void playerTurnEnd()
    {
        if(es.health == 0)
        {
            stopTurns = true;
        }
        pa.locked = true;
        turnStart = true;
        UIController.locked = true;
    }

    public void turnCheck()
    {
        if(turn%2 == 0)
        {
            if(turnStart)
            {
                playerTurnStart();
                turnStart = false;
            }
            else if(playerEnd)
            {
                print("Player ended");
                turn += 1;
                playerTurnEnd();
            }
            else
            {

            }
        }
        else if(enemyWait)
        {
            if(enemyEnd)
            {
                print("Enemy ended");
                turn += 1;
                playerEnd = false;
                enemyWait = false;
                enemyEnd = false;
            }
        }
        else
        {
            ea.actionList();
            enemyWait = true;
            
        }

    }
    
    

}
