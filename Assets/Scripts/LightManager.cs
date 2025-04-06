using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    
    void Start()
    {
        TileManager.OnLevelChanged.AddListener(ReduceLight);
    }

    private void OnDestroy()
    {
        TileManager.OnLevelChanged.RemoveListener(ReduceLight);
    }

    private void ReduceLight()
    {
        if (GameData.CurrentLevel % 3 == 0)
        {
            globalLight.intensity -= 0.1f;
        }
    }
}
