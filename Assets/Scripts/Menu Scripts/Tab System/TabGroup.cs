using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<UITabButton> tabButtons;
    public bool changeSprite = false;

    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    public bool changeColor = false;

    public Color idleColor = Color.white;
    public Color hoverColor = Color.white;
    public Color activeColor = Color.white;

    public bool changeTextColor = false;

    public Color idleText = Color.black;
    public Color hoverText = Color.black;
    public Color activeText = Color.black;

    public UITabButton selectedTab;

    private bool hasStarted = false;

    //public List<GameObject> objectsToSwap;

    public PanelGroup panelGroup;

    public void Start()
    {
        if(selectedTab != null)
        {
            OnTabSelected(selectedTab);
        }

        
        hasStarted = true;
    }

    public void OnEnable()
    {
        if(hasStarted)
        {
            if (selectedTab != null)
            {
                OnTabSelected(selectedTab);
            }
            if (selectedTab == null)
            {
                foreach (UITabButton button in tabButtons)
                {
                    if (button.transform.GetSiblingIndex() == 0)
                    {
                        OnTabSelected(button);
                    }
                }
            }
        }
        
    }

    public void Subscribe(UITabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<UITabButton>();
        }
        tabButtons.Add(button);

        //set order in hierarchy
        //objectList.Sort((x,y) => x.Item.CompareTo(y.Item));
        tabButtons.Sort((x, y) => x.transform.GetSiblingIndex().CompareTo(y.transform.GetSiblingIndex()));

        //If no selected tab, set a default tab
        if (selectedTab == null)
        {
            //Debug.Log("Check");
            foreach (UITabButton tabButton in tabButtons)
            {
                if (tabButton.transform.GetSiblingIndex() == 0)
                {
                    //Debug.Log("Check2");
                    OnTabSelected(tabButton);
                }
            }
        }
    }

    public void OnTabEnter(UITabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {
            if (changeSprite)
            {
                button.background.sprite = tabHover;
            }
            if (changeColor)
            {
                button.background.color = hoverColor;
            }
            if (changeTextColor)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().color = hoverText;
            }
        }
    }

    public void OnTabExit(UITabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(UITabButton button)
    {
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }

        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        
        if (changeSprite)
        {
            button.background.sprite = tabActive;
        }
        if (changeColor)
        {
            button.background.color = activeColor;
        }
        if (changeTextColor)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().color = activeText;
        }

        if (panelGroup != null)
        {
            panelGroup.SetPageIndex(button.transform.GetSiblingIndex());
        }
    }

    public void ResetTabs()
    {
        foreach (UITabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            if (changeSprite)
            {
                button.background.sprite = tabIdle;
            }
            if (changeColor)
            {
                button.background.color = idleColor;
            }
            if (changeTextColor)
            {
                button.GetComponentInChildren<TextMeshProUGUI>().color = idleText;
            }
        }
    }

    public void DesireTab(UITabButton button)
    {
        selectedTab = button;
    }

    public void RemoveDesireTab()
    {
        selectedTab = null;
    }

    public void NextTab()
    {
        int currentIndex = selectedTab.transform.GetSiblingIndex();
        //If current Index is less than the max amount of tabs,
        //Then the next index is the current one + 1
        //If not (current index = end of the tabs) then the next index is just the max amount of tabs (no change)
        int nextIndex = currentIndex < tabButtons.Count - 1 ? currentIndex + 1 : tabButtons.Count - 1;
        OnTabSelected(tabButtons[nextIndex]);
    }

    public void PreviousTab()
    {
        int currentIndex = selectedTab.transform.GetSiblingIndex();
        //If current index is greater than zero
        //Then the next previous index is is the current one - 1
        //If not (it's at 0) then the previous index is just 0 (it stays)
        int previousIndex = currentIndex > 0 ? currentIndex - 1 : 0;
        OnTabSelected(tabButtons[previousIndex]);
    }
}
