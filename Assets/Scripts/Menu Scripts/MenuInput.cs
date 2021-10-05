using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
    PauseMenu pause;
    MenuController menuController;

    public TabGroup[] tabGroup;

    public UITabButton MenuOne;
    public UITabButton MenuTwo;

    // Start is called before the first frame update
    void Start()
    {
        menuController = FindObjectOfType<MenuController>();
        pause = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            //tabGroup[0].selectedTab = MenuTwo;
            pause.Pause(MenuType.SETTINGS);
        }


        for (int i = 0; i < tabGroup.Length; i++)
        {
            if (tabGroup[i].isActiveAndEnabled)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    tabGroup[i].PreviousTab();
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    tabGroup[i].NextTab();
                }
            }
        }
        
    }
}
