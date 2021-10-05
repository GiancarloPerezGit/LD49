using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public MenuController menu;
    public bool pauseExists;
    public PauseMenu pause;
    public bool startWithMenuOn;
    public CanvasObject startMenu;

    public void Start()
    {
        if(startWithMenuOn)
        {
            menu.lastActiveCanvas = startMenu;
        }
         
    }
    public void LoadLevel (string level)
    {
        if(pauseExists)
        {
            pause.Resume();
        }
        
        SceneManager.LoadScene(level);
    }
}
