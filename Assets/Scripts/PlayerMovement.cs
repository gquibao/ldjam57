using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementDelay = 1f;

    private float _xPosition;
    private float _timeElapsed;

    private bool _isForward = true;

    private void Start()
    {
        TileManager.OnLevelChanged.AddListener(LevelChange);
    }

    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= movementDelay)
        {
            Move();
            _timeElapsed = 0;
        }
    }

    private void Move()
    {
        if(_isForward)
        {
            _xPosition += 1;
            if (_xPosition >= GameData.ScreenXRange.y)
            {
                _isForward = false;
            }
        }
        else
        {
            _xPosition -= 1;
            if (_xPosition <= GameData.ScreenXRange.x)
            {
                _isForward = true;
            }
        }

        UpdatePosition();
    }

    private void LevelChange()
    {
        GameData.PlayerY--;
        UpdatePosition();
        if (GameData.CurrentLevel % 10 != 0) return;
        movementDelay -= 0.1f;
        movementDelay = Mathf.Clamp(movementDelay, 0.1f, 1f);
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(_xPosition, GameData.PlayerY);
    }
}
