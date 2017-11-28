using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Health = 150f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var projectile = collider.gameObject.GetComponent<Projectile>();
        if (projectile == null)
        {
            return;
        }

        projectile.Hit();

        Health -= projectile.Damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
