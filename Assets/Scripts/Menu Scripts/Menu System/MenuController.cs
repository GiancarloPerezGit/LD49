using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuController : MonoBehaviour
{
    public List<CanvasObject> canvasObjects;
    Dictionary<MenuType, CanvasObject> canvasObjectDictionary;

    public CanvasObject lastActiveCanvas;

    void Awake()
    {
        //Instantiate the dictionary
        canvasObjectDictionary = new Dictionary<MenuType, CanvasObject>();

        //For each Menu that has a Canvas object script, associate the type in the enum with the Menu thing itself
        foreach (var item in canvasObjects)
        {
            canvasObjectDictionary.Add(item.menu, item);
        }
    }

    public void SwitchMenu(MenuType mT)
    {
        if(lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);  //Deactivate the last active Menu
        }

        CanvasObject desiredCanvas = canvasObjectDictionary[mT]; //Grab the desired Menu from the dictionary the function calls for

        if(desiredCanvas !=null)
        {
            desiredCanvas.gameObject.SetActive(true); //Set the desired menu and make it the last active one
            lastActiveCanvas = desiredCanvas;
        }
    }
    public void MenuOff() //Function to just turn the menu off whenever you see fit
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
    }

    public void ForceMenuOff(MenuType mT) //Function to literally grab the desired menu (Likely the pause menu incase it's still on) and turn it off
    {
        CanvasObject desiredCanvas = canvasObjectDictionary[mT];

        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(false);
        }
    }
}
