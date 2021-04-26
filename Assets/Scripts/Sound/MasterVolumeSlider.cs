using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolumeSlider : MonoBehaviour
{
    // === Variables === //
    public AudioMixer audioMixer;
    public Slider slider;
    private static float currentValue;

    // === Start Method === //
    // Every master volume slider shows the same volume.
    private void Start() 
    {
        slider.value = currentValue;    
    }
    // === SetVolume Method === // 
    // Sets the MasterVolume of the audio mixer.
    public void SetVolume(float volume){
        currentValue = volume;
        audioMixer.SetFloat("MasterVolume", currentValue);
    }

    // === ChangeCurrentVolume Method === //
    // Changes the current volume.
    public static float ChangeCurrentVolume(float volume)
    {
        return currentValue += volume;
    }

}
