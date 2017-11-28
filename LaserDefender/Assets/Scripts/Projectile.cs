using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage = 100f;

    public void Hit()
    {
        Destroy(gameObject);
    }
}
