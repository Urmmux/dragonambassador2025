using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryExpand : MonoBehaviour
{
    public IEnumerator Expand()
    {
        yield return 0;
        //assing this as parent for iteration
        Transform parent = this.transform;

        //get dragon list
        GameObject dragonManager = GameObject.Find("DragonManager");
        List<GameObject> dragonList = dragonManager.GetComponent<DragonList>().dragonList;
        //create list of potential expansions per each dragon, and add dragons to the list
        Dictionary<GameObject, List<GameObject>> dragonExpandableCells = new Dictionary<GameObject, List<GameObject>>();
        foreach (GameObject dragon in dragonList){
            dragonExpandableCells.Add(dragon, new List<GameObject>());
        }

        //iterate over every cell :)
        foreach (Transform child in parent)
        {
            CellStats stats = child.GetComponent<CellStats>();
            if (stats.ownedBy && stats.isExpansionPoint())
            {
                //random chance to kill expansion point
                int rand = Random.Range(1, 3);
                if (rand == 1){
                    stats.tempExpansionPoint = false;
                }
                //borders should be invisible by default
                CellBehavoir cellB = child.GetComponent<CellBehavoir>();
                cellB.BorderInvisible();
                // bool shouldBeVisible = false;

                //check neighbors
                GameObject[] neighbors = GetNeighbors(child);
                foreach (GameObject neighbor in neighbors){
                    CellStats neighborstats = neighbor.GetComponent<CellStats>();
                    if (!neighborstats.ownedBy){
                        //if neighbor is not already owned, add neighbor to possible expasions for the dragon owning the original cell
                        dragonExpandableCells[stats.ownedBy].Add(neighbor);
                        // shouldBeVisible = true;
                    } else if (neighborstats.ownedBy != stats.ownedBy)
                    {
                        //if neighbor is owned, and not owned by the dragon owning the original cell, add a territory grievance
                        stats.ownedBy.GetComponent<DragStats>().Grievance(neighborstats.ownedBy, "territory");
                        // shouldBeVisible = true;
                    }
                }
                // if (shouldBeVisible){
                //     cellB.BorderVisible(stats.ownedBy.GetComponent<DragStats>());
                // }
                //repurpose this for border only along edge so that we can tell apart same-color territories, rename shouldBeVisible to isEdge or something
                cellB.BorderVisible(stats.ownedBy.GetComponent<DragStats>());
            }
        }

        foreach (GameObject dragon in dragonList){
            //set up for random.range base on dragon stats
            DragStats dragStats = dragon.GetComponent<DragStats>();
            int min = 3;
            int max = 8;
            
            if (dragStats.expansionist > 1) {
                max += dragStats.expansionist -1;
                min = 4;
            }

            if (dragStats.moody) {
                min = 0;
                max += 5;
            }
            //decide how many cells to claim and get list of possible cells to claim
            int toClaim = Random.Range(min, max);
            List<GameObject> cells = dragonExpandableCells[dragon];

            //ruler automatically "spends" 1 from toClaim to get cities
            if (dragStats.ruler) {
                foreach (GameObject cell in cells) {
                    CellStats stats = cell.GetComponent<CellStats>();
                    if (stats.has == CellStats.OverworldStructure.City) {
                        stats.ownedBy = dragon;
                        toClaim -= 1;
                        cell.GetComponent<CellBehavoir>().BorderVisible(dragon.GetComponent<DragStats>());
                        stats.tempExpansionPoint = true;
                    }
                }
            }

            for (int i = 0; i < toClaim && cells.Count > 0; i++){
                //get random cell from list of possible cells, assign ownership, set as expansion point
                GameObject cell = cells[Random.Range(0, cells.Count)];
                CellStats stats = cell.GetComponent<CellStats>();
                stats.ownedBy = dragon;
                cell.GetComponent<CellBehavoir>().BorderVisible(dragon.GetComponent<DragStats>());
                stats.tempExpansionPoint = true;

            }
        }
    }

    GameObject[] GetNeighbors(Transform cell)
    {
        List<GameObject> neighbors = new List<GameObject>();

        //get coordinates from name
        string[] parts = cell.name.Replace("cell", "").Split('-');
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);

        //get neighbor coordinates and assign to array
        Vector2Int[] directions = 
        {
        new Vector2Int(0, 1),   // North
        new Vector2Int(1, 0),   // East
        new Vector2Int(0, -1),  // South
        new Vector2Int(-1, 0)   // West
        };

        foreach (Vector2Int dir in directions)
        {
            //using neighbor coordinates, find it and add it to array of neighbors
            string neighborName = $"cell{x + dir.x}-{y + dir.y}";
            GameObject neighbor = GameObject.Find(neighborName);
            if (neighbor != null)
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors.ToArray();
    }

    public void RemoveTerritory(GameObject dragon){
        foreach (Transform child in this.transform)
        {
            //iterate over every cell and if not the dragon's lair, remove all ownership from a specific dragon
            CellStats stats = child.GetComponent<CellStats>();
            if (stats.ownedBy == dragon && stats.has != CellStats.OverworldStructure.Lair)
            {
                stats.ownedBy = null;
                stats.tempExpansionPoint = false;

                CellBehavoir cellB = child.GetComponent<CellBehavoir>();
                cellB.BorderInvisible();
            }
        }
    }
}
