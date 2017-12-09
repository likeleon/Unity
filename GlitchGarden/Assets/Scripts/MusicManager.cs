using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] LevelMusicChanges;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level >= LevelMusicChanges.Length)
        {
            return;
        }

        var thisLevelMusic = LevelMusicChanges[level];
        if (thisLevelMusic == null)
        {
            return;
        }

        _audioSource.clip = thisLevelMusic;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
