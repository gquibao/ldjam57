using System;
using System.Collections;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer firstBackground;
    [SerializeField] private SpriteRenderer secondBackground;
    [SerializeField] private SpriteRenderer thirdBackground;
    private bool _isFading;
    
    private void Start()
    {
        TileManager.OnLevelChanged.AddListener(UpdateBackground);
        
        firstBackground.color = Color.white;
        secondBackground.color = new Color(1, 1, 1, 0);
        thirdBackground.color = new Color(1, 1, 1, 0);
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
        if (GameData.CurrentLevel == 4 || GameData.CurrentLevel == 10)
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
            (firstBackground, thirdBackground) = (thirdBackground, firstBackground);
            (firstBackground, secondBackground) = (secondBackground, firstBackground);
            _isFading = false;
        }
    }
}
