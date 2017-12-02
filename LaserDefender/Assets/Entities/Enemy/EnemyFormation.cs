using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float Health = 150f;
    public GameObject Projectile;
    public float ProjectileSpeed = 10f;
    public float ShotsPerSeconds = 0.5f;

    private void Update()
    {
        float probabilty = Time.deltaTime * ShotsPerSeconds;
        if (Random.value < probabilty)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var beamPosition = transform.position + Vector3.down;
        var beam = Instantiate(Projectile, beamPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -ProjectileSpeed, 0);
    }

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
