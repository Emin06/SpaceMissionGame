using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource ButtonClickSfx;
    public AudioSource CrystalBreakSfx;
    public AudioSource WindSfx;
    public AudioSource BackgroundMusic;

    public Slider MusicSlider;
    public Slider SoundSlider;

    public float MusicSfx;
    public float SoundSfx;

    void Start()
    {
        SoundSfx = 0.4f;
        MusicSfx = 0.1f;

        ButtonClickSfx.volume = SoundSfx * 0.5f;
        CrystalBreakSfx.volume = SoundSfx;
        WindSfx.volume = 0.25f;
        BackgroundMusic.volume = MusicSfx;

        SoundSlider.value = SoundSfx;
        MusicSlider.value = MusicSfx;
    }

    void Update()
    {
        SoundSfx = SoundSlider.value;
        MusicSfx = MusicSlider.value;

        ButtonClickSfx.volume = SoundSfx;
        CrystalBreakSfx.volume = SoundSfx;
        if (SoundSfx == 0)
        {
            WindSfx.volume = 0;
        }
        else
        {
            WindSfx.volume = 0.25f;
        }
        BackgroundMusic.volume = MusicSfx;
    }

    public void ButtonClick()
    {
        ButtonClickSfx.Play();
    }
}
