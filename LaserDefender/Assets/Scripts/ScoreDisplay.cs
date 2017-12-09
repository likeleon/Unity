using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private void Start()
    {
        var myText = GetComponent<Text>();
        myText.text = ScoreKeeper.Score.ToString();
        ScoreKeeper.Reset();
    }
}
