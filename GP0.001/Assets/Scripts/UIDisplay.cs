using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    //update score on display
    public void UpdateScore(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}
