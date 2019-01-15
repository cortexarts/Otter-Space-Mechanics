using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<Transform> tiles;
    public int currentTile = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform tile in tiles)
        {
            if (tile)
            {

            }
        }
    }

    public void SetCurrentTileIndex(int index)
    {
        currentTile = index;
    }
}
