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

    private void Awake()
    {
        OnLevelChanged = new UnityEvent();
        WrongToolUsed = new UnityEvent();
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
                _tileStack.Peek().Add(CreateRandomTile(j, i - GameData.WorldDepth + GameData.PlayerY));
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
        if (_tileStack.Peek()[x].type == type)
        {
            _tileStack.Peek()[x].DestroyTile();
            _currentTiles--;
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
        _currentTiles = _tileStack.Peek().Count;
        GameData.CurrentLevel++;
        OnLevelChanged.Invoke();
    }
}