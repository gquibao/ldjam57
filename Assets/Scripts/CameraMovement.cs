using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TileManager.OnLevelChanged.AddListener(MoveCamera);
    }

    private void OnDestroy()
    {
        TileManager.OnLevelChanged.RemoveListener(MoveCamera);
    }

    private void MoveCamera()
    {
        if (GameData.CurrentLevel % 5 == 0)
        {
            var yPosition = transform.position.y - 5;
            transform.position = new Vector3(3, yPosition, -10);
        }
        
        //TODO smooth camera movement
    }
}
