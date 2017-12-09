using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;

    public AudioClip StartClip;
    public AudioClip GameClip;
    public AudioClip EndClip;

    private AudioSource _music;

    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _music = GetComponent<AudioSource>();
        _music.clip = StartClip;
        _music.loop = true;
        _music.Play();
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer: loaded level " + level);
        _music.Stop();

        if (level == 0)
        {
            _music.clip = StartClip;
        }
        if (level == 1)
        {
            _music.clip = GameClip;
        }
        if (level == 2)
        {
            _music.clip = EndClip;
        }
        _music.loop = true;
        _music.Play();
    }
}
