using UnityEngine;

public class spinning : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Random.Range(-1f, 1f) > 0)
        {
            SpinLeft();
        }
        else
        {
            SpinRight();
        }
    }

    void SpinLeft()
    {
        transform.LeanRotateAroundLocal(new Vector3(0, -1f, 0), 30f, Random.Range(1, 3)).setOnComplete(() =>
        {
            SpinRight();
        });
    }

    void SpinRight()
    {
        transform.LeanRotateAroundLocal(new Vector3(0, 1f, 0), 30f, Random.Range(1, 3)).setOnComplete(() =>
        {
            SpinLeft();
        });
    }
}
