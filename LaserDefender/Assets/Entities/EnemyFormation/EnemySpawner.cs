using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public float Width = 10f;
    public float Height = 5f;
    public float MoveSpeed = 5.0f;

    private bool _movingRight = true;
    private float _minX;
    private float _maxX;

    private void Start()
    {
        var distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        _minX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distanceToCamera)).x;
        _maxX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distanceToCamera)).x;

        foreach (Transform child in transform)
        {
            var enemy = Instantiate(EnemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
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
    }
}
