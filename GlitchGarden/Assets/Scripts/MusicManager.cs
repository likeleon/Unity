using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] LevelMusicChanges;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.buildIndex >= LevelMusicChanges.Length)
        {
            return;
        }

        var thisLevelMusic = LevelMusicChanges[arg0.buildIndex];
        if (thisLevelMusic == null)
        {
            return;
        }

        _audioSource.clip = thisLevelMusic;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float value)
    {
        _audioSource.volume = value;
    }
}
