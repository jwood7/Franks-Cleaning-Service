using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Suck_Script : MonoBehaviour
{
    
    public Tilemap floorMap;
    public Tile slimeFloor;
    public Tile cleanFloor;
    public Sprite heavySlime;
    public Sprite lightSlime;
    Vector3Int prevCell;
    //public Sprite clean;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector3Int currentCell = floorMap.WorldToCell(transform.position);
        Tile tile = floorMap.GetTile<Tile>(currentCell);
        if (tile != null){
            if (tile.sprite == heavySlime && prevCell != currentCell)
            {
                //replace with light slime
                //Debug.Log("heavy slime detected");
                floorMap.SetTile(currentCell,slimeFloor);

            }else if (tile.sprite == lightSlime && prevCell != currentCell)
            {
                //replace with clean floor
                //Debug.Log("light slime detected");
                floorMap.SetTile(currentCell,cleanFloor);
            }
            prevCell = currentCell;
        }
        
    }
}
