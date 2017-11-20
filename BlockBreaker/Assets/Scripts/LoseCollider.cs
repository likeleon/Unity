using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager _levelManager;

    public void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _levelManager.LoadLevel("Win Screen");
    }
}
