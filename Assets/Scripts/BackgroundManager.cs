using System;
using System.Collections;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer firstBackground;
    [SerializeField] private SpriteRenderer secondBackground;
    private bool _isFading;
    
    private void Start()
    {
        TileManager.OnLevelChanged.AddListener(UpdateBackground);
        
        firstBackground.color = Color.white;
        secondBackground.color = new Color(.5f, .3f, 1, 0);
    }

    private void Update()
    {
        if (_isFading)
        {
            FadeOutBackground(firstBackground);
            FadeInBackground(secondBackground);
        }
    }

    private void UpdateBackground()
    {
        if (GameData.CurrentLevel % 2 == 0)
        {
            _isFading = true;
        }
    }

    private void FadeOutBackground(SpriteRenderer background)
    {
        background.color -= new Color(0, 0, 0, Time.deltaTime);
    }
    
    private void FadeInBackground(SpriteRenderer background)
    {
        background.color += new Color(0, 0, 0, Time.deltaTime);
        if (background.color.a >= 1)
        {
            (firstBackground, secondBackground) = (secondBackground, firstBackground);
            _isFading = false;
        }
    }
}
