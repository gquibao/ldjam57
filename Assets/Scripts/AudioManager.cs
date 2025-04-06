using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioSource rocketsAudioSource;
    [SerializeField] private AudioSource uiAudioSource;
    [SerializeField] private AudioSource musicAudioSource;

    [SerializeField] private AudioClip pickaxeClip;
    [SerializeField] private AudioClip shovelClip;
    [SerializeField] private AudioClip wrongToolClip;
    [SerializeField] private AudioClip missedTileClip;
    [SerializeField] private AudioClip rocketsClip;
    [SerializeField] private AudioClip musicClip;

    private void Start()
    {
        TileManager.WrongToolUsed.AddListener(PlayWrongToolSound);
        TileManager.PickaxeUsed.AddListener(PlayPickaxeSound);
        TileManager.ShovelUsed.AddListener(PlayShovelSound);
        PlayerAction.MissedTile.AddListener(MissedTileSound);

        PlayMusic();
        RocketsSound();
    }

    private void PlayMusic()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    private void PlayPickaxeSound()
    {
        playerAudioSource.clip = pickaxeClip;
        playerAudioSource.Play();
    }

    private void PlayShovelSound()
    {
        playerAudioSource.clip = shovelClip;
        playerAudioSource.Play();
    }

    private void PlayWrongToolSound()
    {
        playerAudioSource.clip = wrongToolClip;
        playerAudioSource.Play();
    }
    
    private void MissedTileSound()
    {
        playerAudioSource.clip = missedTileClip;
        playerAudioSource.Play();
    }
    
    private void RocketsSound()
    {
        rocketsAudioSource.clip = rocketsClip;
        rocketsAudioSource.Play();
    }
}
