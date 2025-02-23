using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int _score = 10;
    [SerializeField] private UIDisplay uiDisplay;

    private int _currentScore;

    //increase the score
    public void IncreaseScore()
    {
        _currentScore += _score;
        uiDisplay.UpdateScore(_currentScore);
    }
}
