using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UILink : MonoBehaviour
{
    public TextMeshProUGUI UIElement;
    public bool player = true;
    public bool stability = false;
    public PlayerStats ps;
    public EnemyStats es;
    // Start is called before the first frame update
    void Start()
    {
        if(player)
        {
            if(stability)
            {
                UIElement.text = ps.stability.ToString();
            }
            else
            {
                UIElement.text = ps.health.ToString();
            }
        }
        else
        {
            UIElement.text = es.health.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (stability)
            {
                UIElement.text = ps.stability.ToString();
            }
            else
            {
                UIElement.text = ps.health.ToString();
            }
        }
        else
        {
            UIElement.text = es.health.ToString();
        }
    }
}
