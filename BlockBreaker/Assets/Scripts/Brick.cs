using UnityEngine;

public class Brick : MonoBehaviour
{
    private LevelManager _levelManager;
    private int _timesHit;

    public int MaxHits;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ++_timesHit;

        if (_timesHit >= MaxHits)
        {
            Destroy(gameObject);
        }
    }

    private void SimulateWin()
    {
        _levelManager.LoadNextLevel();
    }
}
