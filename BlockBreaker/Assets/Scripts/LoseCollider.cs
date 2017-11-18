using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    public LevelManager LevelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager.LoadLevel("Win Screen");
    }
}
