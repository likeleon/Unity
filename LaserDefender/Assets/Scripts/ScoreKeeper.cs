using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int Score;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        Reset();
    }

    public void Scored(int points)
    {
        Score += points;
        _text.text = Score.ToString();
    }

    public static void Reset()
    {
        Score = 0;
    }
}
