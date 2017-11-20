using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle _paddle;
    private bool _isStarted;
    private Vector3 _paddleToBall;

    void Start()
    {
        _paddle = FindObjectOfType<Paddle>();
        _paddleToBall = transform.position - _paddle.transform.position;
    }

    void Update()
    {
        if (!_isStarted)
        {
            transform.position = _paddle.transform.position + _paddleToBall;

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);

                _isStarted = true;
            }
        }
    }
}
