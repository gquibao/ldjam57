using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _yTarget;
    private bool _isMoving;

    void Start()
    {
        TileManager.OnLevelChanged.AddListener(CheckForMovement);
    }

    private void Update()
    {
        if (_isMoving && transform.position.y >= _yTarget)
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        else
        {
            _isMoving = false;
        }
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
            _yTarget = transform.position.y - 3;
            _isMoving = true;
        }
        else if (currentLevel % 5 == 0)
        {
            _yTarget = transform.position.y - 5;
            _isMoving = true;
        }
    }
}