using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Slider VolumeSlider;

    public Slider DifficultySlider;

    public LevelManager LevelManager;

    private MusicManager _musicManager;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();

        VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    private void Update()
    {
        _musicManager?.ChangeVolume(VolumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(VolumeSlider.value);
        PlayerPrefsManager.SetDifficulty(DifficultySlider.value);

        LevelManager.LoadLevel("Start");
    }

    public void SetDefaults()
    {
        VolumeSlider.value = 0.8f;
        DifficultySlider.value = 2.0f;
    }
}
