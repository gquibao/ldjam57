using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    public static UnityEvent MissedTile;

    private void Awake()
    {
        MissedTile = new UnityEvent();
    }

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
                MissedTile.Invoke();
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
                MissedTile.Invoke();
            }
        }
    }
}
