using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private void Update()
    {
        if (!GameData.IsAlive()) return;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            try
            {
                TileManager.InteractWithTile((int)transform.position.x, TileType.Dirt);
            }
            catch
            {
                //ignored
            }
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            try
            {
                TileManager.InteractWithTile((int)transform.position.x, TileType.Stone);
            }
            catch
            {
                // ignored
            }
        }
    }
}
