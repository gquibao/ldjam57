using System;
using System.Collections;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer firstBackground;
    [SerializeField] private SpriteRenderer secondBackground;

    private void Start()
    {
        TileManager.OnLevelChanged.AddListener(UpdateBackground);
        
        firstBackground.color = Color.white;
        secondBackground.color = new Color(.5f, .3f, 1, 0);
    }

    private void UpdateBackground()
    {
        if (GameData.CurrentLevel % 2 == 0)
        {
            StartCoroutine(FadeOutBackground(firstBackground));
            StartCoroutine(FadeInBackground(secondBackground));
            (firstBackground, secondBackground) = (secondBackground, firstBackground);
        }
    }

    private IEnumerator FadeOutBackground(SpriteRenderer background)
    {
        while (background.color.a > 0)
        {
            background.color -= new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    private IEnumerator FadeInBackground(SpriteRenderer background)
    {
        while (background.color.a < 1)
        {
            background.color += new Color(0, 0, 0, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
