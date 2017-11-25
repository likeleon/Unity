using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private LevelManager _levelManager;
    private int _timesHit;

    public Sprite[] HitSprites;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBreakable = (tag == "Breakable");
        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        ++_timesHit;
        int maxHits = HitSprites.Length + 1;
        if (_timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = _timesHit - 1;
        if (HitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
    }

    private void SimulateWin()
    {
        _levelManager.LoadNextLevel();
    }
}
