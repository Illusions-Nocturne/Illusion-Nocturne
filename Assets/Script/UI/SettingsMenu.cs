using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider GeneralSound;
    public Slider SFXSound;
    public Slider MusicSound;

    private void OnEnable()
    {
        if (audioMixer.GetFloat("volume", out float v))
            GeneralSound.value = v;

        if (audioMixer.GetFloat("Music", out float m))
            SFXSound.value = m;

        if (audioMixer.GetFloat("SoundEffect", out float e))
            MusicSound.value = e;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }
    public void SetVolumeSound(float volume)
    {
        audioMixer.SetFloat("SoundEffect", volume);
    }
}