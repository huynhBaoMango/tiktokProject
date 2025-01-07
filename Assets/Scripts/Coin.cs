using TikTokLiveSharp.Events.Objects;
using TikTokLiveUnity.Utils;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public TikTokGift gift;
    public Image[] imgs;

    public int score;
    public string user;


    public void InitCoin(TikTokGift gift)
    {
        user = gift.Sender.IdString;
    }

}
