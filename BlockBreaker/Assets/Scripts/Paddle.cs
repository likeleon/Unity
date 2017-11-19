using UnityEngine;

public class Paddle : MonoBehaviour
{
    void Update()
    {
        var mouseWorldPosX = (Input.mousePosition.x / Screen.width) * 16.0f;
        mouseWorldPosX = Mathf.Clamp(mouseWorldPosX, 0.5f, 15.5f);
        transform.position = new Vector3(mouseWorldPosX, transform.position.y);
    }
}
