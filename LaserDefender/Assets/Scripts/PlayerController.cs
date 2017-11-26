using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 15.0f;
    public float Padding = 1f;

    private float _minX;
    private float _maxX;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        _minX = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance)).x + Padding;
        _maxX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance)).x - Padding;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
        }

        var newX = Mathf.Clamp(transform.position.x, _minX, _maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
