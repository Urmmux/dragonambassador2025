using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButtonController : MonoBehaviour
{
    public Button[] buttonArray = new Button[6];
    //do not change Button[0], that one is hardcoded to be the exit button

    public Text[] textArray = new Text[6];

    public void Reset(){
        buttonArray[0].gameObject.SetActive(true);
        buttonArray[1].gameObject.SetActive(false);
        buttonArray[2].gameObject.SetActive(false);
        buttonArray[3].gameObject.SetActive(false);
        buttonArray[4].gameObject.SetActive(false);
        buttonArray[5].gameObject.SetActive(false);
    }

    void OnEnable()
    {
        //add all listeners here for things that want to change the buttons
        DragonBrain.RequestButtons += SetButtons;
        DragonBrain.RequestButtonsExit += SetButtonsExit;
        PlayerFight.RequestButtons += SetButtons;
        PlayerFight.RequestButtonsExit += SetButtonsExit;
        PlayerFight.ButtonsEnable += ButtonsEnable;
        PlayerFight.ButtonsDisable += ButtonsDisable;
    }

    public void ButtonsEnable(){
        foreach (Button b in buttonArray){
            b.interactable = true;
        }
    }

    public void ButtonsDisable(){
        foreach (Button b in buttonArray){
            b.interactable = false;
        }
    }

    void OnDisable()
    {
        //and remove all listeners here
        DragonBrain.RequestButtons -= SetButtons;
        DragonBrain.RequestButtonsExit += SetButtonsExit;
        PlayerFight.RequestButtons -= SetButtons;
        PlayerFight.RequestButtonsExit -= SetButtonsExit;
    }

    public void SetButtons(ButtonInfo[] buttons)
    {
        //since not a time we can exit the location, hide exit button
        buttonArray[0].gameObject.SetActive(false);

        for (int i = 0; i < buttons.Length && i < 6; i++)
        {
            //for each button we have info for, set active, assign label, and assign button function
            buttonArray[i+1].gameObject.SetActive(true);
            textArray[i+1].text = buttons[i].label;
            buttonArray[i+1].onClick.RemoveAllListeners();
            buttonArray[i+1].onClick.AddListener(buttons[i].onClick);
        }

        for (int i = buttons.Length + 1; i < 6; i++){
            //fore each button we don't have info for, disable
            buttonArray[i].gameObject.SetActive(false);
            buttonArray[i].onClick.RemoveAllListeners();
        }
    }

    public void SetButtonsExit(ButtonInfo[] buttons)
    {
        //same as SetButtons but the exit button is visible
        buttonArray[0].gameObject.SetActive(true);

        for (int i = 0; i < buttons.Length && i < 6; i++)
        {
            buttonArray[i+1].gameObject.SetActive(true);
            textArray[i+1].text = buttons[i].label;
            buttonArray[i+1].onClick.RemoveAllListeners();
            buttonArray[i+1].onClick.AddListener(buttons[i].onClick);
        }

        for (int i = buttons.Length; i < 6; i++){
            buttonArray[i].gameObject.SetActive(false);
            buttonArray[i].onClick.RemoveAllListeners();
        }
    }

    
}
