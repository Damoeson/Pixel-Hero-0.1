using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damoeson
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryPage inventoryUI;

        public PlayerInputHandler InputHandler { get; private set; }

        public int inventorySize = 10;

        private void Start()
        {
            InputHandler = GetComponent<PlayerInputHandler>();

            inventoryUI.InitializeInventoryUI(inventorySize);
        }

        private void Update()
        {
            if (InputHandler.InventoryInput)
            {
                if(inventoryUI.isActiveAndEnabled == false)
                {
                    inventoryUI.Show();
                    InputHandler.UseInventoryInput();
                }

                else
                {
                    inventoryUI.Hide();
                    InputHandler.UseInventoryInput();
                }
            }
        }
    }
}
