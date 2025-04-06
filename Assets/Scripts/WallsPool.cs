using System.Collections.Generic;
using UnityEngine;

public class WallsPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> pool;

    private const float WallSize = 5;

    void Start()
    {
        TileManager.OnLevelChanged.AddListener(UpdatePool);
    }

    private void UpdatePool()
    {
        if (GameData.CurrentLevel % 5 == 0)
        {
            Reorder(0);
            Reorder(0);
        }
    }

    private void Reorder(int index)
    {
        var temp = pool[index];
        pool.RemoveAt(index);
        pool.Add(temp);
        var targetYPosition = temp.transform.localPosition.y - (pool.Count * WallSize);
        Debug.Log(Vector3.up * targetYPosition);
        temp.transform.localPosition = new Vector3(0, targetYPosition, 0);
    }
}
