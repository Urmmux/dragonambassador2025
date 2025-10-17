using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lairScreen;

    public GameObject shipWreckScreen;

    public GameObject ruinsScreen;

    public GameObject caveScreen;

    public GameObject cityScreen;

    public GameObject townScreen;

    public GameObject dragon;

    private TerritoryExpand territoryExpand;


    void Start()
    {
        territoryExpand = GameObject.Find("void").GetComponent<TerritoryExpand>();
    }

    public void OpenLocation(CellStats cellStats) {
        //run if statement depending on what location it is
        if (cellStats.has == CellStats.OverworldStructure.Lair){
            lairScreen.SetActive(true);
            //get the owner of the lair
            dragon = cellStats.ownedBy;
            DragStats stats = dragon.GetComponent<DragStats>();
            //make dragon visible
            dragon.transform.GetChild(0).gameObject.SetActive(true);
            //reset buttons just in case, run dialogue
            lairScreen.GetComponentInChildren<LocationButtonController>().Reset();
            dragon.GetComponent<DragonBrain>().RunDialog(lairScreen);
        } else if (cellStats.has == CellStats.OverworldStructure.City){
            cityScreen.SetActive(true);

        } else if (cellStats.has == CellStats.OverworldStructure.Cave){
            caveScreen.SetActive(true);

        } else if (cellStats.has == CellStats.OverworldStructure.Ruins){
            ruinsScreen.SetActive(true);

        } else if (cellStats.has == CellStats.OverworldStructure.Shipwreck){
            shipWreckScreen.SetActive(true);

        } else if (cellStats.has == CellStats.OverworldStructure.Town) {
            townScreen.SetActive(true);
        }

        StartCoroutine(territoryExpand.Expand());
    }

    public void CloseLocation() {
        
        lairScreen.SetActive(false);
        cityScreen.SetActive(false);
        caveScreen.SetActive(false);
        ruinsScreen.SetActive(false);
        shipWreckScreen.SetActive(false);
        townScreen.SetActive(false);

        if (dragon) {
            dragon.transform.GetChild(0).gameObject.SetActive(false);
            dragon = null; 
        }
    }
}
