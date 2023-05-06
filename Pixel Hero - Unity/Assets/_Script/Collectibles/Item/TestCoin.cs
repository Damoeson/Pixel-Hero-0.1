using System;
using UnityEngine;

namespace Damoeson
{
    public class TestCoin : MonoBehaviour, ICollectibles
    {
        public static event HandleCoinCollected OnCoinCollected;

        public delegate void HandleCoinCollected(ItemData itemData);

        public ItemData coinData;

        public void Collect()
        {
            Destroy(gameObject);
            SoundManager.instance.PlaySound(coinData.CollectedSound);
            OnCoinCollected?.Invoke(coinData);
        }
    }
}
