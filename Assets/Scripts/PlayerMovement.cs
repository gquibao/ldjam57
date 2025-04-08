using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float movementDelay = 1f;

    private float _xPosition;
    private float _timeElapsed;

    private bool _isForward = true;

    public static UnityEvent PlayerDied;

    private void Awake()
    {
        PlayerDied = new UnityEvent();
    }

    private void Start()
    {
        TileManager.OnLevelChanged.AddListener(LevelChange);
    }

    private void OnDestroy()
    {
        TileManager.OnLevelChanged.RemoveListener(LevelChange);
    }

    void Update()
    {
        if (!GameData.IsPlaying) return;
        
        if (!GameData.IsAlive())
        {
            PlayerDied.Invoke();
            return;
        }
        
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= movementDelay)
        {
            Move();
            _timeElapsed = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            UseTool(TileType.Dirt);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            UseTool(TileType.Stone);
        }
    }

    public void UseTool(int toolId)
    {
        if (GameData.IsPlaying && GameData.IsAlive())
        {
            var type = toolId == 0 ? TileType.Dirt : TileType.Stone;
            UseTool(type);
        }
    }
    
    private void UseTool(TileType type)
    {
        TileManager.InteractWithTile((int)transform.position.x, type);
        var animTrigger = type == TileType.Stone ? "pickaxe" : "shovel";
        animator.SetTrigger(animTrigger);
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
        movementDelay = Mathf.Clamp(movementDelay, 0.05f, 1f);
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(_xPosition, GameData.PlayerY);
    }
}
