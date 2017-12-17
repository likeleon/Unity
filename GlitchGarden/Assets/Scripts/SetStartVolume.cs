using UnityEngine;

public class SetStartVolume : MonoBehaviour
{
    private MusicManager _musicManager;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();
        if (_musicManager != null)
        {
            var volume = PlayerPrefsManager.GetMasterVolume();
            _musicManager.SetVolume(volume);
        }
    }
}
