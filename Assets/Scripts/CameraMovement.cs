using System;
using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TileManager.OnLevelChanged.AddListener(CheckForMovement);
    }

    private void OnDestroy()
    {
        TileManager.OnLevelChanged.RemoveListener(CheckForMovement);
    }

    private void CheckForMovement()
    {
        var currentLevel = GameData.CurrentLevel;
        if (currentLevel == 2)
        {
            var yPosition = transform.position.y - 3;
            StartCoroutine(MoveCamera(yPosition));
        }
        else if (currentLevel % 5 == 0)
        {
            var yPosition = transform.position.y - 5;
            StartCoroutine(MoveCamera(yPosition));
        }
    }

    private IEnumerator MoveCamera(float yTarget)
    {
        while (transform.position.y >= yTarget)
        {
            transform.position += Vector3.down * (Time.deltaTime * 5);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
