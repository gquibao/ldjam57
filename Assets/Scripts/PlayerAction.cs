using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    public static UnityEvent MissedTile;

    private void Awake()
    {
        MissedTile = new UnityEvent();
    }

    private void Update()
    {
        if (!GameData.IsPlaying || !GameData.IsAlive()) return;
        
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
            
            animator.SetTrigger("shovel");
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            try
            {
                TileManager.InteractWithTile((int)transform.position.x, TileType.Stone);
            }
            catch
            {
                MissedTile.Invoke();
            }
            animator.SetTrigger("pickaxe");
        }
    }
}
