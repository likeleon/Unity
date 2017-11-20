using UnityEngine;

public class Brick : MonoBehaviour
{
    private int _timesHit;

    public int MaxHits;

    void OnCollisionEnter2D(Collision2D collision)
    {
        ++_timesHit;
    }
}
