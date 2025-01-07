using System.Collections;
using System.Collections.Generic;
using TikTokLiveSharp.Client;
using TikTokLiveSharp.Events;
using TikTokLiveSharp.Events.Objects;
using TikTokLiveUnity.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TikTokLiveUnity.Example
{
    public class LiveManager : MonoBehaviour
    {
        #region Properties
        [Header("Settings")]
        [SerializeField]
        [Tooltip("Duration for objects to exist")]
        private float timeToLive = 3f;

        // private GameObject rowPrefab;

        [SerializeField]
        [Tooltip("Prefab for Row to display Gift")]
        private tiktokGift giftRowPrefab;

        List<long> giftList = new List<long>()
        {
            5655, // rose, 200d
            6052, // gamepad, 2000d
            6070, // Mirror, 6000d
            5707, // Love you, 10000d
            6104, // cap, 20000d
            5509, // sunglasses, 40000d
            6267, // corgi, 120000d
        };

        public List<GameObject> coinsPrefab = new List<GameObject>();
        public List<Transform> spawns = new List<Transform>();

        public Transform coinParent;


        private TikTokLiveManager mgr => TikTokLiveManager.Instance;

        /// <summary>
        /// Initializes this Object
        /// </summary>
        private IEnumerator Start()
        {
            mgr.OnLike += OnLike;
            mgr.OnChatMessage += OnComment;
            mgr.OnGift += OnGift;
            for (int i = 0; i < 3; i++)
                yield return null; // Wait 3 frames in case Auto-Connect is enabled

        }


        private void OnDestroy()
        {
            if (!TikTokLiveManager.Exists)
                return;
            mgr.OnLike -= OnLike;
            mgr.OnChatMessage -= OnComment;
            mgr.OnGift -= OnGift;
        }

        private void OnGift(TikTokLiveClient sender, TikTokGift gift)
        {
            GiftCheck(gift);
        }

        /// <summary>
        /// Handler for Like-Event
        /// </summary>
        private void OnLike(TikTokLiveClient sender, Like like)
        {
            
        }
        /// <summary>
        /// Handler for Comment-Event
        /// </summary>
        private void OnComment(TikTokLiveClient sender, Chat comment)
        {
            
        }
        /// <summary>
        /// Requests Image from TikTokLive-Manager
        /// </summary>
        /// <param name="img">UI-Image used for display</param>
        /// <param name="picture">Data for Image</param>
        private void RequestImage(Image img, Picture picture)
        {
            Dispatcher.RunOnMainThread(() =>
            {
                mgr.RequestSprite(picture, spr =>
                {
                    if (img != null && img.gameObject != null && img.gameObject.activeInHierarchy)
                        img.sprite = spr;
                });
            });
        }

        private void GiftCheck(TikTokGift gift)
        {
            if (gift.Gift.Id == giftList[0])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[0], 1, gift)); // 200
            }

            if (gift.Gift.Id == giftList[1])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[0], 10, gift)); // 2.000
            }

            if (gift.Gift.Id == giftList[2])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[0], 30, gift)); // 6.000
            }

            if (gift.Gift.Id == giftList[3])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[0], 30, gift)); //10.000
                StartCoroutine(SpawnCoin(coinsPrefab[1], 4, gift));
            }

            if (gift.Gift.Id == giftList[4])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[1], 20, gift)); //20.000
            }

            if (gift.Gift.Id == giftList[5])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[1], 45, gift)); // 40.000
            }

            if (gift.Gift.Id == giftList[6])
            {
                StartCoroutine(SpawnCoin(coinsPrefab[0], 150, gift)); // 120.000
                StartCoroutine(SpawnCoin(coinsPrefab[0], 100, gift)); // 120.000
            }
        }


        IEnumerator SpawnCoin(GameObject coin, int amount, TikTokGift gift)
        {
            int order = 0;
            for(int i = 0; i < amount; i++)
            {
                GameObject newCoin = Instantiate(coin, spawns[order].position, Quaternion.Euler(90, 0, 0));
                RequestImage(newCoin.GetComponent<Coin>().imgs[0], gift.Sender.AvatarThumbnail);
                RequestImage(newCoin.GetComponent<Coin>().imgs[1], gift.Sender.AvatarThumbnail);
                if (order < 2) order++;
                else order = 0;
                yield return new WaitForSeconds(1f);
            }
        }

        #endregion
    }
}
