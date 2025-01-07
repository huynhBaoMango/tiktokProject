using System;
using System.Collections.Generic;
using TikTokLiveSharp.Events.Objects;
using TikTokLiveUnity.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TikTokLiveUnity.Example
{
    /// <summary>
    /// Displays Gift (with Updates) in ExampleScene
    /// </summary>
    public class tiktokGift : MonoBehaviour
    {
        /// <summary>
        /// Gift being Displayed
        /// </summary>
        public TikTokGift Gift { get; private set; }

        [SerializeField]
        [Tooltip("Image displaying ProfilePicture of Sender")]
        private Image imgUserProfile;
        /// <summary>
        /// Image displaying Icon for Gift
        /// </summary>
        [SerializeField]
        [Tooltip("Image displaying Icon for Gift")]
        private Image imgGiftIcon;

        [SerializeField]
        private List<GameObject> coins;

        List<long> giftList = new List<long>()
        {
            5655, // rose
            5650, // mic
            6052, // gamepad
            6070, // Mirror
            5707, // Love you
            6104, // cap
            5509, // sunglasses
            6267, // corgi
        };

        public void Init(TikTokGift gift)
        {
            Gift = gift;
            Gift.OnAmountChanged += AmountChanged;
            Gift.OnStreakFinished += StreakFinished;
            RequestImage(imgUserProfile, Gift.Sender.AvatarThumbnail);
            RequestImage(imgGiftIcon, Gift.Gift.Image);
            // Run Streak-End for non-streakable gifts
            if (gift.StreakFinished)
                StreakFinished(gift, gift.Amount);
        }
        /// <summary>
        /// Deinitializes GiftRow
        /// </summary>
        private void OnDestroy()
        {
            gameObject.SetActive(false);
            if (Gift == null)
                return;
            Gift.OnAmountChanged -= AmountChanged;
            Gift.OnStreakFinished -= StreakFinished;
        }
        /// <summary>
        /// Updates Gift-Amount if Amount Changed
        /// </summary>
        /// <param name="gift">Gift for Event</param>
        /// <param name="newAmount">New Amount</param>
        private void AmountChanged(TikTokGift gift, long change, long newAmount)
        {
           // txtAmount.text = $"{newAmount}x";

            GiftCheck(gift);
        }

        private void GiftCheck(TikTokGift gift)
        {
            if(gift.Gift.Id == giftList[0])
            {
                
            }

            if (gift.Gift.Id == giftList[1])
            {

            }

            if (gift.Gift.Id == giftList[2])
            {

            }

            if (gift.Gift.Id == giftList[3])
            {

            }

            if (gift.Gift.Id == giftList[4])
            {

            }

            if (gift.Gift.Id == giftList[5])
            {

            }

            if (gift.Gift.Id == giftList[6])
            {

            }

            if (gift.Gift.Id == giftList[7])
            {

            }
        }

        /// <summary>
        /// Called when GiftStreaks Ends. Starts Destruction-Timer
        /// </summary>
        /// <param name="gift">Gift for Event</param>
        /// <param name="finalAmount">Final Amount for Streak</param>
        private void StreakFinished(TikTokGift gift, long finalAmount)
        {
            AmountChanged(gift, 0, finalAmount);
            Destroy(gameObject, 2f);
        }
        /// <summary>
        /// Requests Image from TikTokLive-Manager
        /// </summary>
        /// <param name="img">UI-Image used for display</param>
        /// <param name="picture">Data for Image</param>
        private static void RequestImage(Image img, Picture picture)
        {
            Dispatcher.RunOnMainThread(() =>
            {
                if (TikTokLiveManager.Exists)
                    TikTokLiveManager.Instance.RequestSprite(picture, spr =>
                    {
                        if (img != null && img.gameObject != null && img.gameObject.activeInHierarchy)
                            img.sprite = spr;
                    });
            });
        }
    }
}