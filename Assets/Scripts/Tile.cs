using UnityEngine;
using UnityEngine.Serialization;

public class Tile : MonoBehaviour
{
    public TileType type;
    [FormerlySerializedAs("_isBroken")] public bool isBroken;

    public void DestroyTile()
    {
        isBroken = true;
        Destroy(gameObject);
    }
}

public enum TileType
{
    Dirt,
    Stone
}
