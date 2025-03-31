using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public string Team;
    private ScoreCounter counter;
    void Start()
    {
        counter = GameObject.FindWithTag("Counter").GetComponent<ScoreCounter>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<Coin>() != null)
        {
            int score = collision.GetComponent<Coin>().score;
            counter.AddScore(Team, score);
            Destroy(collision.gameObject, 3f);
        }
    }
}
