using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
