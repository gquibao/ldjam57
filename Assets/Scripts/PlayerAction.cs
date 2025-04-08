using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        if (!GameData.IsPlaying || !GameData.IsAlive()) return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            TileManager.InteractWithTile((int)transform.position.x, TileType.Dirt);
            animator.SetTrigger("shovel");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TileManager.InteractWithTile((int)transform.position.x, TileType.Stone);
            animator.SetTrigger("pickaxe");
        }
    }
}