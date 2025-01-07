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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    void SpawnManyBigCoin()
    {
        StartCoroutine(SpawnManyBigCoin1(10));
    }

    [Button]
    void Shake()
    {
        machine.transform.LeanRotateAroundLocal(new Vector3(0, 0, 1f), 10f, 0.1f).setOnComplete(() =>
        {
            machine.transform.LeanRotateAroundLocal(new Vector3(0, 0, 1f), -20f, 0.1f).setOnComplete(() =>
            {
                machine.transform.LeanRotateZ(0, 0.1f);
            });
        });
    }


    IEnumerator SpawnManyBigCoin1(int value)
    {
        for(int i = 0; i < value; i++)
        {
            Vector3 spawnPos = new Vector3(floatList[Random.Range(0, floatList.Count)], transform.position.y, transform.position.z);
            Instantiate(bigCoin, spawnPos, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(1f);
        }
    }

}
