using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private Text _Scoretext;

    //update score on display
    public void UpdateScore(int currentScore)
    {
        _score++;
        Debug.Log("SCORE: " + _score);

        _Scoretext.text = "SCORE:" + _score;
    }
}
