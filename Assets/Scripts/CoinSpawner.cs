using DG.Tweening;
using NaughtyAttributes;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject bigCoin;
    public GameObject machine;
    List<float> floatList = new List<float> { -0.3f, 0.3f };


    void Start()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        gameObject.transform.DOMoveX(-23.6f, 10f).OnComplete(() =>
        {
            MoveRight();
        });
    }

    void MoveRight()
    {
        gameObject.transform.DOMoveX(23.6f, 10f).OnComplete(() =>
        {
            MoveLeft();
        });
    }
    

}
