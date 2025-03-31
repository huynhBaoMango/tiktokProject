using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [Header("Team 1")]
    public Image badge1, frame1;
    public Image curImg1;
    public TextMeshProUGUI scoreT1;
    public Image nextImg1;

    [Header("Team 1")]
    public Image badge2, frame2;
    public Image curImg2;
    public TextMeshProUGUI scoreT2;
    public Image nextImg2;

    public Sprite winSp, loseSp;

    public void UpdateWinAndLose(Sprite player1, long score1, Sprite player2, long score2)
    {
        curImg1.sprite = player1;
        curImg2.sprite = player2;
        scoreT1.text = score1.ToString();
        scoreT2.text = score2.ToString();

        if(score1 == score2)
        {
            badge1.sprite = winSp;
            badge2.sprite = winSp;
        }
        else if(score1 < score2)
        {
            badge2.sprite = winSp;
            badge1.sprite = loseSp;

            curImg1.color = ColorUtility.TryParseHtmlString("#8E8E8E", out Color color) ? color : curImg1.color;
            frame1.color = ColorUtility.TryParseHtmlString("#292929", out Color color1) ? color1 : frame1.color;

            curImg2.color = ColorUtility.TryParseHtmlString("#FFFFFF", out Color color2) ? color2 : curImg2.color;
            frame2.color = ColorUtility.TryParseHtmlString("#FFFFFF", out Color color3) ? color3 : frame2.color;
        }
        else
        {
            badge1.sprite = winSp;
            badge2.sprite = loseSp;

            curImg2.color = ColorUtility.TryParseHtmlString("#8E8E8E", out Color color) ? color : curImg2.color;
            frame2.color = ColorUtility.TryParseHtmlString("#292929", out Color color1) ? color1 : frame2.color;

            curImg1.color = ColorUtility.TryParseHtmlString("#FFFFFF", out Color color2) ? color2 : curImg1.color;
            frame1.color = ColorUtility.TryParseHtmlString("#FFFFFF", out Color color3) ? color3 : frame1.color;
        }
    }

    public void UpdateNextMatch(Sprite player1, Sprite player2)
    {
        nextImg1.sprite = player1;
        nextImg2.sprite = player2;
    }
}
