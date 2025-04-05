using UnityEngine;
using Random = UnityEngine.Random;

public class TilesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject dirtPrefab;
    [SerializeField] private GameObject stonePrefab;

    public GameObject[,] Tiles = new GameObject[7, 10];

    private void Start()
    {
        for (int i = 0; i < Tiles.GetLength(0); i++)
        {
            for (int j = 0; j < Tiles.GetLength(1); j++)
            {
                Tiles[i, j] = Instantiate(GetTileType(), new Vector3(i-3, j-7), Quaternion.identity);
            }
        }
    }

    private GameObject GetTileType()
    {
        return Random.Range(0, 2) == 1 ? dirtPrefab : stonePrefab;
    }
}
