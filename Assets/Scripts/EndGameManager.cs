using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{

    public Image badge1, frame1;
    public Image curImg1;
    public TextMeshProUGUI scoreT1;
    public Image nextImg1;

    public Image badge2, frame2;
    public Image curImg2;
    public TextMeshProUGUI scoreT2;
    public Image nextImg2;

    public Sprite winSp, loseSp;
    public GameObject canvas;

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
            scoreT1.color = ColorUtility.TryParseHtmlString("#292929", out Color color11) ? color11 : scoreT1.color;

            curImg2.color = ColorUtility.TryParseHtmlString("#FFFFFF", out Color color2) ? color2 : curImg2.color;
            frame2.color = ColorUtility.TryParseHtmlString("#FFEF00", out Color color3) ? color3 : frame2.color;
            scoreT2.color = ColorUtility.TryParseHtmlString("#FFEF00", out Color color22) ? color22 : scoreT2.color;
        }
        else
        {
            badge1.sprite = winSp;
            badge2.sprite = loseSp;

            curImg2.color = ColorUtility.TryParseHtmlString("#8E8E8E", out Color color) ? color : curImg2.color;
            frame2.color = ColorUtility.TryParseHtmlString("#292929", out Color color1) ? color1 : frame2.color;
            scoreT2.color = ColorUtility.TryParseHtmlString("#292929", out Color color11) ? color11 : scoreT2.color;

            curImg1.color = ColorUtility.TryParseHtmlString("#FFFFFF", out Color color2) ? color2 : curImg1.color;
            frame1.color = ColorUtility.TryParseHtmlString("#FFEF00", out Color color3) ? color3 : frame1.color;
            scoreT1.color = ColorUtility.TryParseHtmlString("#FFEF00", out Color color22) ? color22 : scoreT1.color;
        }
    }

    public void UpdateNextMatch(Sprite player1, Sprite player2)
    {
        nextImg1.sprite = player1;
        nextImg2.sprite = player2;
    }

    public void FadeIn()
    {
        canvas.transform.DOScale(0, 0);
        canvas.transform.DOScale(1, 1f).SetEase(Ease.OutElastic, 0.1f, 0.5f);
    }

    public void FadeOut()
    {
        canvas.transform.DOScale(0, 1f).SetEase(Ease.InElastic, 0.1f, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
