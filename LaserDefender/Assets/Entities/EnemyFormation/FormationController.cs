using UnityEngine;

public class FormationController : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public float Width = 10f;
    public float Height = 5f;
    public float MoveSpeed = 5.0f;
    public float SpawnDelay = 0.5f;

    private bool _movingRight = true;
    private float _minX;
    private float _maxX;

    private void Start()
    {
        var distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        _minX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceToCamera)).x;
        _maxX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceToCamera)).x;

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            SpawnEnemy(child);
        }
    }

    private void SpawnEnemy(Transform transform)
    {
        var enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = transform;
    }

    private void SpawnUntilFull()
    {
        var freePosition = GetNextFreePosition();
        if (freePosition != null)
        {
            SpawnEnemy(freePosition);
        }

        if (GetNextFreePosition() != null)
        {
            Invoke(nameof(SpawnUntilFull), SpawnDelay);
        }
    }

    private Transform GetNextFreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount <= 0)
            {
                return child;
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height));
    }

    private void Update()
    {
        if (_movingRight)
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }

        float formationRight = transform.position.x + (0.5f * Width);
        float formationLeft = transform.position.x - (0.5f * Width);
        if (formationLeft < _minX)
        {
            _movingRight = true;
        }
        else if (formationRight > _maxX)
        {
            _movingRight = false;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    private bool AllMembersDead()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
