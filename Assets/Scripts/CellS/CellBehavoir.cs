using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CellStats.Terrain;
using static CellStats.OverworldStructure;

public class CellBehavoir : MonoBehaviour
{

    public SpriteRenderer cellBorder;

    private GameObject dragonPrefab;
    void Start()
    {
        //get stuff
        dragonPrefab = Resources.Load<GameObject>("dragon");
        CellStats currentStats = gameObject.GetComponent<CellStats>();
        GameObject go = gameObject;

        if (currentStats.has == Lair)
        {
            //create lair sprite (dragon is assigned later)
            GameObject newgo = new GameObject();
            newgo.name = "lairsprite" + go.name;
            newgo.transform.parent = go.transform;
            newgo.transform.position = go.transform.position;

            newgo.AddComponent<SpriteRenderer>();
            SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
            sp.sprite = Resources.Load("dragonroost", typeof(Sprite)) as Sprite;
            sp.sortingLayerName = "locations";

        }

        if (currentStats.type == Deep)
        {
            //reference here for how to get different sprites for the same location
            if (Random.Range(1, 3) == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("deep2", typeof(Sprite)) as Sprite;
            }

            //check for wrecked ships
            if (Random.Range(1, 1000) == 1 && currentStats.has == None)
            {
                currentStats.has = Shipwreck;

                GameObject newgo = new GameObject();
                newgo.name = "shipwrecksprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("emptycell", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";

            }

        }

        if (currentStats.type == Field && currentStats.has == None)
        {
            //check if city or town
            int randomIndex = Random.Range(1, 300);
            if (randomIndex == 1)
            {
                currentStats.has = City;

                GameObject newgo = new GameObject();
                newgo.name = "citysprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("city", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
            else if (randomIndex < 3)
            {

                currentStats.has = Town;

                GameObject newgo = new GameObject();
                newgo.name = "townsprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("town", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
        }


        if (currentStats.type == Mountain && currentStats.has == None)
        {
            //check for caves
            int randomIndex = Random.Range(1, 250);
            if (randomIndex == 1)
            {

                currentStats.has = Cave;

                GameObject newgo = new GameObject();
                newgo.name = "cavesprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("cave", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
        }

        if (currentStats.type == Forest && currentStats.has == None)
        {
            //check for caves, ruins, or towns
            int randomIndex = Random.Range(1, 700);
            if (randomIndex == 1)
            {
                currentStats.has = Cave;

                GameObject newgo = new GameObject();
                newgo.name = "cavesprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("cave", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
            else if (randomIndex < 3)
            {
                currentStats.has = Ruins;

                GameObject newgo = new GameObject();
                newgo.name = "ruinsprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("ruins", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
            else if (randomIndex < 6)
            {
                currentStats.has = Town;

                GameObject newgo = new GameObject();
                newgo.name = "townsprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("town", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
        }

        if (currentStats.type == Shroom && currentStats.has == None)
        {
            //check for ruins
            int randomIndex = Random.Range(1, 50);
            if (randomIndex == 1)
            {
                currentStats.has = Ruins;

                GameObject newgo = new GameObject();
                newgo.name = "ruinsprite" + go.name;
                newgo.transform.parent = go.transform;
                newgo.transform.position = go.transform.position;

                newgo.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = newgo.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("ruins", typeof(Sprite)) as Sprite;
                sp.sortingLayerName = "locations";
            }
        }
        //here we assign dragons
        if (currentStats.has == Lair)
        {
            //get lists of all dragons and lairs
            List<GameObject> dragonList = GameObject.Find("DragonManager").GetComponent<DragonList>().dragonList;
            var lairList = this.gameObject.transform.parent.gameObject.GetComponent<Gridinitialize>().lairList;
            lairList.Add(this.gameObject);
            //create a dragon
            var dragon = Instantiate(dragonPrefab);
            dragon.name = "dragon"+lairList.Count;
            //assign this as the dragon's roost
            dragon.GetComponent<DragStats>().homeRoost = this.gameObject;
            currentStats.homeTo = dragon;
            currentStats.ownedBy = dragon;
            //move the dragon off the screen
            dragon.transform.GetChild(0).transform.position = new Vector3(0, -40, 0);
            //add dragon to list
            dragonList.Add(dragon);
        }

        //give water tag for movement purposes
        if (currentStats.type == Deep){
            go.tag = "water";
        }

        //add border sprite
        GameObject bordergo = new GameObject();
        bordergo.name = "bordersprite" + go.name;
        bordergo.transform.parent = go.transform;
        bordergo.transform.position = go.transform.position;

        cellBorder = bordergo.AddComponent<SpriteRenderer>();
        cellBorder.sprite = Resources.Load("border", typeof(Sprite)) as Sprite;
        cellBorder.sortingLayerName = "locations";
        cellBorder.sortingOrder = -1;
        cellBorder.enabled = false;


    }

    public void BorderVisible(DragStats dragon) 
    {
        Color color = new Color(1, 1, 1, 0.9f);
        if (dragon.favColor == "Red"){
            color = new Color(0.4339623f, 0.1903702f, 0.1903702f, 0.9f);
        }
        if (dragon.favColor == "Gold"){
            color = new Color(0.6603774f, 0.5714236f, 0.4080634f, 0.9f);
        }
        if (dragon.favColor == "Green"){
            color = new Color(0.5168962f, 0.5849056f, 0.4773051f, 0.9f);
        }
        if (dragon.favColor == "Blue"){
            color = new Color(0.1850876f, 0.1818707f, 0.6320754f, 0.8f);
        }
        cellBorder.enabled = true;
        cellBorder.color = color;
    }

    public void BorderInvisible(){
        cellBorder.enabled = false;
    }

    void Update()
    {

    }
}
