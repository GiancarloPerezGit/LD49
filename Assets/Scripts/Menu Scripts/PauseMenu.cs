using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public MonoBehaviour[] inputScripts;

    readonly MenuType pauseType = MenuType.PAUSE;

    MenuController menuController;

    public bool menuActive;

    void Start()
    {
        menuController = FindObjectOfType<MenuController>();
        menuController.ForceMenuOff(pauseType);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuActive)
            {
                Resume();
            } else
            {
                Pause(pauseType);
            }
        }
    }

    public void Pause(MenuType menu)
    {
        menuController.SwitchMenu(menu);

        Time.timeScale = 0f;
        menuActive = true;

        for(int i = 0; i < inputScripts.Length; i++)
        {
            inputScripts[i].enabled = false;
        }
        
    }

    public void Resume()
    {
        menuController.MenuOff();

        Time.timeScale = 1f;
        menuActive = false;

        for (int i = 0; i < inputScripts.Length; i++)
        {
            inputScripts[i].enabled = true;
        }

    }
}
