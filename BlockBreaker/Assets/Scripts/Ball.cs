using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle Paddle;

    private bool _isStarted;
    private Vector3 _paddleToBall;

    void Start()
    {
        _paddleToBall = transform.position - Paddle.transform.position;
    }
    
    void Update()
    {
        if (!_isStarted)
        {
            transform.position = Paddle.transform.position + _paddleToBall;

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);

                _isStarted = true;
            }
        }
    }
}
