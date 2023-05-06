using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damoeson
{
    public class Collector : MonoBehaviour
    {
        private bool isColliding;

        private void Update()
        {
            isColliding = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isColliding) return;
            isColliding = true;

            ICollectibles collectibles = collision.GetComponent<ICollectibles>();

            if (collectibles != null)
            {
                collectibles.Collect();
            }  
        }
    }
}
