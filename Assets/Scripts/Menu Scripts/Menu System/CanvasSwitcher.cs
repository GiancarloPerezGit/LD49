using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public MenuType desiredMenu;

    public bool isTab;
    public TabGroup tabGroup;
    public UITabButton desiredButton;

    MenuController menuController;
    Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);

        menuController = FindObjectOfType<MenuController>();

        //if(menuController)
        //{
        //    Debug.Log(menuController.name);
        //}

    }

    // Update is called once per frame
    void OnButtonClicked()
    {
        menuController.SwitchMenu(desiredMenu);

        if(isTab)
        {
            tabGroup.OnTabSelected(desiredButton);
            //tabGroup.DesireTab(desiredButton);
        }
    }
}
