using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(-1f, 1.5f)]
    public float WalkSpeed;

    private void Update()
    {
        transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
    }
}
