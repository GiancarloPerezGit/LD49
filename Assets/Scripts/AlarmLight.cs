using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public Color redLight;

    public Color dimLight;

    Color lerpedColor;

    Light alarmLight;

    public float timeScale;
    public PlayerStats ps;
    // Start is called before the first frame update
    void Start()
    {
        alarmLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(redLight, dimLight, Mathf.PingPong(Time.time * timeScale, 1));
        alarmLight.color = lerpedColor;
        if(ps.stability > 80)
        {
            timeScale = 0.5f;
        }
        else if(ps.stability > 60)
        {
            timeScale = 0.75f;
        }
        else if(ps.stability > 40)
        {
            timeScale = 1f;
        }
        else if(ps.stability > 20)
        {
            timeScale = 1.25f;
        }
        else
        {
            timeScale = 1.5f;
        }
    }
}
