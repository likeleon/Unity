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

        SimulateWin();
    }

    private void SimulateWin()
    {
        _levelManager.LoadNextLevel();
    }
}
