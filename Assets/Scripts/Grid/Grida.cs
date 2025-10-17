using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CellStats.Terrain;
using static CellStats.OverworldStructure;
public class Grida
{

    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    public GameObject[,] cellArray;

    public Grida(int width, int height, float cellSize, GameObject parent)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        cellArray = new GameObject[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = new GameObject();
                go.name = "cell" + x + "-" + y;
                go.transform.parent = parent.transform;
                go.transform.position = GetWorldPosition(x, y);

                go.AddComponent<SpriteRenderer>();
                SpriteRenderer sp = go.GetComponent<SpriteRenderer>();
                sp.sprite = Resources.Load("emptycell", typeof(Sprite)) as Sprite;

                go.AddComponent<BoxCollider2D>();

                go.layer = 11;
                go.tag = "walkable";


                cellArray[x, y] = go;

            }
        }
        //starting seed generation
        int i = 0;
        while (i < 5)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    float modifier = 1f + (((Mathf.Abs((width / 2) - x) ^ 2) + (Mathf.Abs((height / 2) - y)) ^ 2) ^ 4);
                    float randomIndex = Random.Range(1, modifier);

                    if (randomIndex >= 1 && randomIndex <= 2)
                    {
                        i++;
                        GameObject go = cellArray[x, y];
                        SpriteRenderer sp = go.GetComponent<SpriteRenderer>();
                        sp.sprite = Resources.Load("field", typeof(Sprite)) as Sprite;
                    }
                    else
                    {
                        GameObject go = cellArray[x, y];
                        SpriteRenderer sp = go.GetComponent<SpriteRenderer>();
                        sp.sprite = Resources.Load("deep1", typeof(Sprite)) as Sprite;
                    }
                }
            }
        }
        //end seed generation

        //land grower
        i = 0;
        while (i < 7)
        {
            i++;
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    GameObject goWest;
                    GameObject goEast;
                    GameObject goSouth;
                    GameObject goNorth;

                    if (x != 0)
                    {
                        goWest = cellArray[x - 1, y];
                    }
                    else
                    {
                        goWest = null;
                    }
                    if (x != width - 1)
                    {
                        goEast = cellArray[x + 1, y];
                    }
                    else
                    {
                        goEast = null;
                    }
                    if (y != 0)
                    {
                        goSouth = cellArray[x, y - 1];
                    }
                    else
                    {
                        goSouth = null;
                    }
                    if (y != height - 1)
                    {
                        goNorth = cellArray[x, y + 1];
                    }
                    else
                    {
                        goNorth = null;
                    }
                    int modifier = 1 - i;
                    modifier -= i;
                    bool landTrue = false;

                    if (goWest)
                    {
                        if (goWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            landTrue = true;

                        }
                    }
                    if (goEast)
                    {
                        if (goEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            landTrue = true;
                        }
                    }
                    if (goNorth)
                    {
                        if (goNorth.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            landTrue = true;
                        }
                    }
                    if (goSouth)
                    {
                        if (goSouth.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            modifier++;
                            landTrue = true;

                        }
                    }
                    if (landTrue == true)
                    {
                        int randomIndex = Random.Range(-4, 7);
                        modifier += randomIndex;

                        if (modifier >= 1)
                        {
                            go.GetComponent<SpriteRenderer>().sprite = Resources.Load("emptycell", typeof(Sprite)) as Sprite;

                        }
                    }
                }
            }
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    if (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("emptycell", typeof(Sprite)) as Sprite)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("field", typeof(Sprite)) as Sprite;
                    }
                }
            }
        }
        //end land grower

        //lake shrinker
        i = 0;
        while (i < 5)
        {
            i++;
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    GameObject goWest;
                    GameObject goEast;
                    GameObject goSouth;
                    GameObject goNorth;

                    if (x != 0)
                    {
                        goWest = cellArray[x - 1, y];
                    }
                    else
                    {
                        goWest = null;
                    }
                    if (x != width - 1)
                    {
                        goEast = cellArray[x + 1, y];
                    }
                    else
                    {
                        goEast = null;
                    }
                    if (y != 0)
                    {
                        goSouth = cellArray[x, y - 1];
                    }
                    else
                    {
                        goSouth = null;
                    }
                    if (y != height - 1)
                    {
                        goNorth = cellArray[x, y + 1];
                    }
                    else
                    {
                        goNorth = null;
                    }
                    int modifier = 0;

                    if (goWest)
                    {
                        if (goWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;

                        }
                    }
                    if (goEast)
                    {
                        if (goEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;

                        }
                    }
                    if (goNorth)
                    {
                        if (goNorth.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;

                        }
                    }
                    if (goSouth)
                    {
                        if (goSouth.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                        {
                            modifier++;

                        }
                    }

                    if (modifier >= 2)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("emptycell", typeof(Sprite)) as Sprite;

                    }
                }
            }
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    if (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("emptycell", typeof(Sprite)) as Sprite)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("field", typeof(Sprite)) as Sprite;
                    }
                }
            }
        }
        //end lake shrinker

        //mountain seed

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];
                GameObject goWest;
                GameObject goEast;
                GameObject goWWest;
                GameObject goEEast;
                bool mountainTrue = false;

                if (x != 0)
                {
                    goWest = cellArray[x - 1, y];
                    if (x != 1)
                    {
                        goWWest = cellArray[x - 2, y];
                    }
                    else
                    {
                        goWWest = null;
                    }
                }
                else
                {
                    goWest = null;
                    goWWest = null;
                }
                if (x != width - 1)
                {
                    goEast = cellArray[x + 1, y];
                    if (x != width - 2)
                    {
                        goEEast = cellArray[x + 2, y];
                    }
                    else
                    {
                        goEEast = null;
                    }
                }
                else
                {
                    goEast = null;
                    goEEast = null;
                }
                bool mountainLikely = false;

                if (goWest && goEast)
                {
                    if (goWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite && go.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite && goEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                    {
                        mountainTrue = true;

                    }
                }
                if (goWWest && goEEast)
                {
                    if (goWWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite && goEEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                    {
                        mountainLikely = true;
                    }
                }

                int randomIndex;

                if (mountainTrue == true)
                {
                    if (mountainLikely == true)
                    {
                        randomIndex = Random.Range(1, 600);
                    }
                    else
                    {
                        randomIndex = Random.Range(1, 1400);
                    }
                    if (randomIndex == 1)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("mountain", typeof(Sprite)) as Sprite;
                    }
                }

            }

        }

        //mountain grow
        i = 0;
        while (i < 15)
        {
            i++;
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    GameObject goWest;
                    GameObject goEast;
                    GameObject goSouth;
                    GameObject goNorth;
                    if (x != 0)
                    {
                        goWest = cellArray[x - 1, y];
                    }
                    else
                    {
                        goWest = null;
                    }
                    if (x != width - 1)
                    {
                        goEast = cellArray[x + 1, y];
                    }
                    else
                    {
                        goEast = null;
                    }
                    if (y != 0)
                    {
                        goSouth = cellArray[x, y - 1];
                    }
                    else
                    {
                        goSouth = null;
                    }
                    if (y != height - 1)
                    {
                        goNorth = cellArray[x, y + 1];
                    }
                    else
                    {
                        goNorth = null;
                    }
                    bool rangeTrue = false;

                    if (goWest)
                    {
                        if (goWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("mountian", typeof(Sprite)) as Sprite)
                        {
                            rangeTrue = true;

                        }
                    }
                    if (goEast)
                    {
                        if (goEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("mountain", typeof(Sprite)) as Sprite)
                        {
                            rangeTrue = true;

                        }
                    }
                    if (goNorth)
                    {
                        if (goNorth.GetComponent<SpriteRenderer>().sprite == Resources.Load("mountain", typeof(Sprite)) as Sprite)
                        {
                            rangeTrue = true;

                        }
                    }
                    if (goSouth)
                    {
                        if (goSouth.GetComponent<SpriteRenderer>().sprite == Resources.Load("mountain", typeof(Sprite)) as Sprite)
                        {
                            rangeTrue = true;

                        }
                    }
                    int randomIndex = Random.Range(1, 5);
                    bool landTrue = go.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite;

                    if (landTrue && rangeTrue && randomIndex == 1)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("emptycell", typeof(Sprite)) as Sprite;
                    }


                }
            }
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    if (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("emptycell", typeof(Sprite)) as Sprite)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("mountain", typeof(Sprite)) as Sprite;
                    }
                }
            }
        }
        //end mountain grow

        //forest seed
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];
                bool isField = (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite);
                if (isField)
                {
                    int randomIndex = Random.Range(1, 200);
                    if (randomIndex == 1)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("forest", typeof(Sprite)) as Sprite;
                    }
                }
            }
        }
        //forest seed end

        //forest grow
        i = 0;
        while (i < 5)
        {
            i++;
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    GameObject goWest;
                    GameObject goEast;
                    GameObject goSouth;
                    GameObject goNorth;
                    bool forestNear = false;

                    if (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                    {

                        if (x != 0)
                        {
                            goWest = cellArray[x - 1, y];
                        }
                        else
                        {
                            goWest = null;
                        }
                        if (x != width - 1)
                        {
                            goEast = cellArray[x + 1, y];
                        }
                        else
                        {
                            goEast = null;
                        }
                        if (y != 0)
                        {
                            goSouth = cellArray[x, y - 1];
                        }
                        else
                        {
                            goSouth = null;
                        }
                        if (y != height - 1)
                        {
                            goNorth = cellArray[x, y + 1];
                        }
                        else
                        {
                            goNorth = null;
                        }
                        if (goWest)
                        {
                            if (goWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("forest", typeof(Sprite)) as Sprite)
                            {
                                forestNear = true;

                            }
                        }
                        if (goEast)
                        {
                            if (goEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("forest", typeof(Sprite)) as Sprite)
                            {
                                forestNear = true;

                            }
                        }
                        if (goNorth)
                        {
                            if (goNorth.GetComponent<SpriteRenderer>().sprite == Resources.Load("forest", typeof(Sprite)) as Sprite)
                            {
                                forestNear = true;

                            }
                        }
                        if (goSouth)
                        {
                            if (goSouth.GetComponent<SpriteRenderer>().sprite == Resources.Load("forest", typeof(Sprite)) as Sprite)
                            {
                                forestNear = true;

                            }
                        }
                        if (forestNear)
                        {
                            int forestChance = Random.Range(1, 7) - i;
                            if (forestChance >= 2)
                            {
                                go.GetComponent<SpriteRenderer>().sprite = Resources.Load("forest", typeof(Sprite)) as Sprite;
                            }
                        }
                    }

                }
            }
        }
        //end forest grow

        //shroom seed
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];
                bool isField = (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite);
                if (isField)
                {
                    int randomIndex = Random.Range(1, 400);
                    if (randomIndex == 1)
                    {
                        go.GetComponent<SpriteRenderer>().sprite = Resources.Load("shroom", typeof(Sprite)) as Sprite;
                    }
                }
            }
        }
        //shroom seed end

        //shroom grow
        i = 0;
        while (i < 2)
        {
            i++;
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject go = cellArray[x, y];
                    GameObject goWest;
                    GameObject goEast;
                    GameObject goSouth;
                    GameObject goNorth;
                    bool shroomNear = false;

                    if (go.GetComponent<SpriteRenderer>().sprite == Resources.Load("field", typeof(Sprite)) as Sprite)
                    {

                        if (x != 0)
                        {
                            goWest = cellArray[x - 1, y];
                        }
                        else
                        {
                            goWest = null;
                        }
                        if (x != width - 1)
                        {
                            goEast = cellArray[x + 1, y];
                        }
                        else
                        {
                            goEast = null;
                        }
                        if (y != 0)
                        {
                            goSouth = cellArray[x, y - 1];
                        }
                        else
                        {
                            goSouth = null;
                        }
                        if (y != height - 1)
                        {
                            goNorth = cellArray[x, y + 1];
                        }
                        else
                        {
                            goNorth = null;
                        }
                        if (goWest)
                        {
                            if (goWest.GetComponent<SpriteRenderer>().sprite == Resources.Load("shroom", typeof(Sprite)) as Sprite)
                            {
                                shroomNear = true;

                            }
                        }
                        if (goEast)
                        {
                            if (goEast.GetComponent<SpriteRenderer>().sprite == Resources.Load("shroom", typeof(Sprite)) as Sprite)
                            {
                                shroomNear = true;

                            }
                        }
                        if (goNorth)
                        {
                            if (goNorth.GetComponent<SpriteRenderer>().sprite == Resources.Load("shroom", typeof(Sprite)) as Sprite)
                            {
                                shroomNear = true;

                            }
                        }
                        if (goSouth)
                        {
                            if (goSouth.GetComponent<SpriteRenderer>().sprite == Resources.Load("shroom", typeof(Sprite)) as Sprite)
                            {
                                shroomNear = true;

                            }
                        }
                        if (shroomNear)
                        {
                            int shroomChance = Random.Range(1, 10) - i;
                            if (shroomChance >= 4)
                            {
                                go.GetComponent<SpriteRenderer>().sprite = Resources.Load("shroom", typeof(Sprite)) as Sprite;
                            }
                        }
                    }

                }
            }
        }
        //end shroom grow

        //add statholder script
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];

                go.AddComponent<CellStats>();

                CellStats currentCellStats = go.GetComponent<CellStats>();

                Sprite sp = go.GetComponent<SpriteRenderer>().sprite;

                if (sp == Resources.Load("field", typeof(Sprite)) as Sprite)
                {
                    currentCellStats.type = Field;
                }
                else if (sp == Resources.Load("mountain", typeof(Sprite)) as Sprite)
                {
                    currentCellStats.type = Mountain;
                }
                else if (sp == Resources.Load("forest", typeof(Sprite)) as Sprite)
                {
                    currentCellStats.type = Forest;
                }
                else if (sp == Resources.Load("shroom", typeof(Sprite)) as Sprite)
                {
                    currentCellStats.type = Shroom;
                }
                else
                {
                    currentCellStats.type = Deep;
                }
            }
        }
        //end statholder script

        //Lair randomizer
        for (int x = 35; x < gridArray.GetLength(0); x += 35)
        {

            for (int y = 25; y < gridArray.GetLength(1); y += 25)
            {
                GameObject go = cellArray[x, y];

                CellStats currentCellStats = go.GetComponent<CellStats>();

                currentCellStats.has = Lair;
            }
        }

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];

                CellStats currentCellStats = go.GetComponent<CellStats>();

                if (currentCellStats.has == Lair)
                {

                    if (currentCellStats.type == Mountain)
                    {
                        break;
                    }
                    else if (currentCellStats.type == Field || currentCellStats.type == Shroom || currentCellStats.type == Forest || currentCellStats.type == Deep)
                    {
                        GameObject newgo = cellArray[x, y];
                        CellStats newCellStats = newgo.GetComponent<CellStats>();
                        i = 0;
                        int q = 2;
                        while (newCellStats.type != Mountain && i < 40)
                        {
                            i++;
                            if (i == 4 || i == 8 || i == 12 || i == 16 || i == 20 || i == 24 || i == 28 || i == 32 || i == 36)
                            {
                                q++;
                            }
                            int randomIndex = Random.Range(1, 9);
                            switch (randomIndex)
                            {
                                case 1:
                                    newgo = cellArray[x - q, y];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 2:
                                    newgo = cellArray[x + q, y];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 3:
                                    newgo = cellArray[x, y - q];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 4:
                                    newgo = cellArray[x, y + q];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 5:
                                    newgo = cellArray[x + q, y + q];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 6:
                                    newgo = cellArray[x - q, y - q];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 7:
                                    newgo = cellArray[x - q, y + q];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                case 8:
                                    newgo = cellArray[x + q, y - q];
                                    newCellStats = newgo.GetComponent<CellStats>();
                                    break;
                                default:
                                    break;
                            }

                        }
                        currentCellStats.has = None;
                        newCellStats.has = Town;
                    }
                    else
                    {
                        break;
                    }

                }

            }
        }
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];

                CellStats currentCellStats = go.GetComponent<CellStats>();

                if (currentCellStats.has == Town)
                {
                    {
                        currentCellStats.has = Lair;
                    }
                }
            }
        }
        //end Lair randomizer

        //add cell behavoir
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject go = cellArray[x, y];

                go.AddComponent<CellBehavoir>();
            }
        }
        //end cell behavoir





    }
    Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
}
