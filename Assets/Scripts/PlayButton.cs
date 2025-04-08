using System;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(!GameData.IsPlaying)
            GameData.IsPlaying = true;
    }
}
