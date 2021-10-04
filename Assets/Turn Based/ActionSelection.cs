using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionSelection : MonoBehaviour
{
    public int actionNumber = 0;
    public RawImage rawShoot;
    public RawImage rawHeal;
    public RawImage rawDefend;
    public RawImage rawStabilize;
    public PlayerActions pa;

    public bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cursorAdjustment()
    {
        rawShoot.color = new Color(1, 1, 1, 0.282353f);
        rawHeal.color = new Color(1, 1, 1, 0.282353f);
        rawDefend.color = new Color(1, 1, 1, 0.282353f);
        rawStabilize.color = new Color(1, 1, 1, 0.282353f);
        if (actionNumber == 0)
        {
            rawShoot.color = new Color(0, 0, 1, 0.282353f);
        }
        else if (actionNumber == 1)
        {
            rawHeal.color = new Color(0, 0, 1, 0.282353f);
        }
        else if (actionNumber == 2)
        {
            rawDefend.color = new Color(0, 0, 1, 0.282353f);
        }
        else if (actionNumber == 3)
        {
            rawStabilize.color = new Color(0, 0, 1, 0.282353f);
        }
    }

    public void actionSelect()
    {
        if(actionNumber == 0)
        {
            pa.Shoot();
        }
        else if (actionNumber == 1)
        {
            pa.Heal();
        }
        else if (actionNumber == 2)
        {
            pa.Defend();
        }
        else if (actionNumber == 3)
        {
            pa.Stabilize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!locked)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                actionNumber -= 1;
                if (actionNumber < 0)
                {
                    actionNumber += 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                actionNumber -= 2;
                if (actionNumber < 0)
                {
                    actionNumber += 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                actionNumber += 1;
                if (actionNumber > 3)
                {
                    actionNumber -= 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                actionNumber += 2;
                if (actionNumber > 3)
                {
                    actionNumber -= 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                actionSelect();
            }
        }
        
    }
}
