using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TileManager : MonoBehaviour
{
    [SerializeField] private GameObject dirtPrefab;
    [SerializeField] private GameObject stonePrefab;

    private static Stack<List<Tile>> _tileStack;
    private static int _currentTiles;

    public static UnityEvent OnLevelChanged;
    public static UnityEvent WrongToolUsed;
    public static UnityEvent PickaxeUsed;
    public static UnityEvent ShovelUsed;
    public static UnityEvent GameFinished;

    private void Awake()
    {
        OnLevelChanged = new UnityEvent();
        WrongToolUsed = new UnityEvent();
        GameFinished = new UnityEvent();
        PickaxeUsed = new UnityEvent();
        ShovelUsed = new UnityEvent();
    }

    private void Start()
    {
        CreateTiles();
    }

    private void CreateTiles()
    {
        _tileStack = new();

        for (var i = 0; i < GameData.WorldDepth; i++)
        {
            _tileStack.Push(new List<Tile>());
            for (var j = 0; j < 7; j++)
            {
                _tileStack.Peek().Add(CreateRandomTile(j, i - GameData.WorldDepth + GameData.PlayerY - 1));
            }

            _currentTiles = _tileStack.Peek().Count;
        }
    }

    private Tile CreateRandomTile(int x, int y)
    {
        GameObject tileObject;
        if (Random.Range(0, 2) == 1)
        {
            tileObject = Instantiate(dirtPrefab, new Vector3(x, y), Quaternion.identity);
        }
        else
        {
            tileObject = Instantiate(stonePrefab, new Vector3(x, y), Quaternion.identity);
        }

        return tileObject.GetComponent<Tile>();
    }

    public static void InteractWithTile(int x, TileType type)
    {
        var tile = _tileStack.Peek()[x];
        
        if (tile.type == type)
        {
            if (type == TileType.Stone)
            {
                PickaxeUsed.Invoke();
            }
            else
            {
                ShovelUsed.Invoke();
            }

            _tileStack.Peek()[x].DestroyTile();
            _currentTiles--;
            _tileStack.Peek()[x] = null;
            
            if (_currentTiles == 0)
            {
                NextLevel();
            }
        }

        else
        {
            GameData.PlayerLives--;
            WrongToolUsed.Invoke();
        }
    }

    private static void NextLevel()
    {
        _tileStack.Pop();
        if (_tileStack.Count != 0)
        {
            _currentTiles = _tileStack.Peek().Count;
            GameData.CurrentLevel++;
            OnLevelChanged.Invoke();
        }
        else
        {
            GameFinished.Invoke();
        }
    }
}