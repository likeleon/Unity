using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool IsAutoPlay;

    private Ball _ball;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (!IsAutoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    private void MoveWithMouse()
    {
        var mouseWorldPosX = (Input.mousePosition.x / Screen.width) * 16.0f;
        SetPositionX(mouseWorldPosX);
    }

    private void SetPositionX(float x)
    {
        x = Mathf.Clamp(x, 0.5f, 15.5f);
        transform.position = new Vector3(x, transform.position.y);
    }

    private void AutoPlay()
    {
        var ballPosX = _ball.transform.position.x;
        SetPositionX(ballPosX);
    }
}
