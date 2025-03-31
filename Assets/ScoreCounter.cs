using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public long scoreTeam1, scoreTeam2;

    public TextMeshProUGUI text1, text2;

    void Start()
    {
        scoreTeam1 = 0;
        scoreTeam2 = 0;
        UpdateText();
    }

    public void AddScore(string team, int score)
    {
        if(team == "team1")
        {
            scoreTeam1 += score;

        }
        if (team == "team2")
        {
            scoreTeam2 += score;
        }

        UpdateText();
    }

    void UpdateText()
    {
        text1.text = scoreTeam1+"";
        text2.text = scoreTeam2+"";
    }
}
