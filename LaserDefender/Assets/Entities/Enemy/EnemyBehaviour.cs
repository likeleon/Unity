using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Health = 150f;
    public GameObject Projectile;
    public float ProjectileSpeed = 10f;
    public float ShotsPerSeconds = 0.5f;
    public int ScoreValue = 150;
    public AudioClip FireSound;
    public AudioClip DeathSound;

    private ScoreKeeper _scoreKeeper;

    private void Start()
    {
        _scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

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
        var beam = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -ProjectileSpeed, 0);

        AudioSource.PlayClipAtPoint(FireSound, transform.position);
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
            Die();
        }
    }

    private void Die()
    {
        _scoreKeeper.Scored(ScoreValue);

        AudioSource.PlayClipAtPoint(DeathSound, transform.position);

        Destroy(gameObject);
    }
}
