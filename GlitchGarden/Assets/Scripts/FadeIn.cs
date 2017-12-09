using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour 
{
    public float FadeInTime;

    private Image _fadePanel;
    private Color _currentColor = Color.black;

    private void Start()
    {
        _fadePanel = GetComponent<Image>();
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad < FadeInTime)
        {
            float alphaChange = Time.deltaTime / FadeInTime;
            _currentColor.a -= alphaChange;
            _fadePanel.color = _currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
