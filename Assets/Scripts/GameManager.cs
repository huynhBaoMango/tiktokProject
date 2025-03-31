using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public TextMeshProUGUI timerText;
    public float elapsedTime;

    public Image imgTeam1, imgTeam2;
    public List<Sprite> sprites;


    public Sprite winSp, loseSp;

    public GameObject EndGameUI;
    
    void Start()
    {
        SetUpFirstTime();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(elapsedTime / 60);
        int sec = Mathf.FloorToInt(elapsedTime % 60);
        
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    void SetUpFirstTime()
    {
        sprites = Resources.LoadAll<Sprite>("Images").ToList();
        StartARound();
    }

    void StartARound()
    {
        elapsedTime = 60 * 15;
        scoreCounter.scoreTeam1 = 0;
        scoreCounter.scoreTeam2 = 0;

        int randomIndex = Random.Range(0, sprites.Count);
        imgTeam1.sprite = sprites[randomIndex];
        sprites.RemoveAt(randomIndex);

        int randomIndex2 = Random.Range(0, sprites.Count);
        imgTeam2.sprite = sprites[randomIndex2];
        sprites.RemoveAt(randomIndex2);
    }
}
