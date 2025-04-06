using DG.Tweening;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public string Team;
    public GameObject fx;
    public AudioClip pointSound;
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
            GameObject a = Instantiate(fx, collision.transform.position, Quaternion.identity);
            SoundFxManager.instance.PlaySFX(pointSound, transform, 0.5f);
            a.transform.DOScale(15f, 0f);
            Destroy(collision.gameObject, 3f);
        }
    }
}
