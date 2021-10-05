using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActionSelection : MonoBehaviour
{
    public int actionNumber = 0;
    public RawImage rawShoot;
    public RawImage rawHeal;
    public RawImage rawDefend;
    public RawImage rawStabilize;
    public PlayerActions pa;
    public TextMeshProUGUI descript;
    public bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cursorAdjustment()
    {
        rawShoot.color = new Color(0, 0, 0, 0.282353f);
        rawHeal.color = new Color(0, 0, 0, 0.282353f);
        rawDefend.color = new Color(0, 0, 0, 0.282353f);
        rawStabilize.color = new Color(0, 0, 0, 0.282353f);
        if (actionNumber == 0)
        {
            rawShoot.color = new Color(0, 0, 1, 0.282353f);
            descript.text = "2 Damage\n30% Chance to lower stability by 10";
        }
        else if (actionNumber == 1)
        {
            rawHeal.color = new Color(0, 0, 1, 0.282353f);
            descript.text = "Heal 5 hp";
        }
        else if (actionNumber == 2)
        {
            rawDefend.color = new Color(0, 0, 1, 0.282353f);
            descript.text = "Reduce next damage taken by half (rounded down)";
        }
        else if (actionNumber == 3)
        {
            rawStabilize.color = new Color(0, 0, 1, 0.282353f);
            descript.text = "Restore 50 stability";
        }
    }

    public void actionSelect()
    {
        locked = true;
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
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                actionNumber -= 1;
                if (actionNumber < 0)
                {
                    actionNumber += 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                actionNumber -= 2;
                if (actionNumber < 0)
                {
                    actionNumber += 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                actionNumber += 1;
                if (actionNumber > 3)
                {
                    actionNumber -= 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                actionNumber += 2;
                if (actionNumber > 3)
                {
                    actionNumber -= 4;
                }
                cursorAdjustment();
            }
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                actionSelect();
            }
        }
        
    }
}
