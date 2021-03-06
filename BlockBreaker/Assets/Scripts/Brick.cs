﻿using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int BreakableCount;

    public Sprite[] HitSprites;
    public AudioClip Crack;
    public GameObject Smoke;

    private LevelManager _levelManager;
    private int _timesHit;
    private bool _isBreakable;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();

        _isBreakable = (tag == "Breakable");
        if (_isBreakable)
        {
            ++BreakableCount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(Crack, transform.position, 0.8f);

        if (_isBreakable)
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
            var smoke = Instantiate(Smoke, transform.position, Quaternion.identity);
            var main = smoke.GetComponent<ParticleSystem>().main;
            main.startColor = GetComponent<SpriteRenderer>().color;

            --BreakableCount;
            _levelManager.BrickDestroyed();

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
}
