using DG.Tweening;
using NaughtyAttributes;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public ScoreCounter scoreCounter;
    public TextMeshProUGUI timerText;
    public float elapsedTime;

    public Image imgTeam1, imgTeam2;
    public List<Sprite> sprites;

    public EndGameManager EndGameUI;

    public bool isPlaying;
    public int curIndex1, curIndex2;
    public List<int> used;
    public GameObject machine;

    public float cooldownShake = 0f;
    
    void Start()
    {
        SetUpFirstTime();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownShake > 0f)
        {
            cooldownShake -= Time.deltaTime;
        }
        if (isPlaying)
        {
            if (elapsedTime > 0)
            {
                elapsedTime -= Time.deltaTime;
                int min = Mathf.FloorToInt(elapsedTime / 60);
                int sec = Mathf.FloorToInt(elapsedTime % 60);

                timerText.text = string.Format("{0:00}:{1:00}", min, sec);
            }
            else
            {
                isPlaying = false;
                EndGameTrigger();
            }
        }
    }

    public void StartGame()
    {
        isPlaying=true;
    }

    void SetUpFirstTime()
    {
        sprites = Resources.LoadAll<Sprite>("Images").ToList();
        curIndex1 = -1;
        curIndex2 = -1;
        GetCurIndex();
        StartARound();
    }

    void StartARound()
    {
        elapsedTime = 5;
        scoreCounter.scoreTeam1 = 0;
        scoreCounter.scoreTeam2 = 4;
        imgTeam1.sprite = sprites[curIndex1];
        imgTeam2.sprite = sprites[curIndex2];

    }

    void GetCurIndex()
    {
        if(used.Count >= sprites.Count - 1)
        {
            used.Clear();
        }

        if (curIndex1 == -1)
        {
            curIndex1 = GetUniqueRandomNumber(0, sprites.Count-1, used);
        }

        if (curIndex2 == -1)
        {
            do
            {
                curIndex2 = GetUniqueRandomNumber(0, sprites.Count-1, used);
            } while (curIndex1 == curIndex2);
        }
    }

    void EndGameTrigger()
    {
        EndGameUI.gameObject.SetActive(true);
        EndGameUI.FadeIn();
        EndGameUI.UpdateWinAndLose(imgTeam1.sprite, scoreCounter.scoreTeam1, imgTeam2.sprite, scoreCounter.scoreTeam2);

        if(scoreCounter.scoreTeam1 > scoreCounter.scoreTeam2)
        {
            used.Add(curIndex2);
            curIndex2 = -1;

        }
        else
        {
            used.Add(curIndex1);
            curIndex1 = curIndex2;
            curIndex2 = -1;
            
        }

        GetCurIndex();
        EndGameUI.UpdateNextMatch(sprites[curIndex1], sprites[curIndex2]);
        StartCoroutine(CloseEndGameUI());
    }

    int GetUniqueRandomNumber(int min, int max, List<int> usedNumbers)
    {
        List<int> availableNumbers = Enumerable.Range(min, max - min + 1).Except(usedNumbers).ToList();
        return availableNumbers.Count > 0 ? availableNumbers[Random.Range(0, availableNumbers.Count)] : -1;
    }

    IEnumerator CloseEndGameUI()
    {
        yield return new WaitForSeconds(10f);
        EndGameUI.FadeOut();
        StartARound();
        isPlaying = true;
    }

    public void Shake()
    {
        if(cooldownShake > 0) return;

        cooldownShake = 10f;
        machine.transform.LeanRotateAroundLocal(new Vector3(0, 0, 1f), 10f, 0.1f).setOnComplete(() =>
        {
            machine.transform.LeanRotateAroundLocal(new Vector3(0, 0, 1f), -20f, 0.1f).setOnComplete(() =>
            {
                machine.transform.LeanRotateZ(0, 0.1f);
            });
        });
    }

    [Button]
    public void LeanMachine()
    {
        machine.transform.LeanRotateAroundLocal(new Vector3(1f, 0, 0), -60f, 0.1f);
        machine.transform.DOMoveY(machine.transform.position.y + 50f, 1f);
    }
}
