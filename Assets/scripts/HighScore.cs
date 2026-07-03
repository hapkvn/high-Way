using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TMP_Text t_Score;
    private void Start()
    {
        int h_score = PlayerPrefs.GetInt("HighScore", 0);
        
            t_Score.text = h_score.ToString();
        
    }
}
