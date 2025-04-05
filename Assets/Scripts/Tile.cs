using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType type;

    public void DestroyTile()
    {
        Destroy(gameObject);
    }
}

public enum TileType
{
    Dirt,
    Stone
}
