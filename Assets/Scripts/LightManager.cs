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
        if (GameData.CurrentLevel == GameData.SecondLayer)
        {
            globalLight.intensity -= 0.3f;
        }
        else if (GameData.CurrentLevel > GameData.SecondLayer && GameData.CurrentLevel < GameData.ThirdLayer)
        {
            globalLight.intensity -= 0.2f;
        }
        else if (GameData.CurrentLevel == GameData.ThirdLayer)
        {
            globalLight.color = new Color(0.7f, 0.3f, 0.1f);
            globalLight.intensity = 0.1f;
        }
    }
}
