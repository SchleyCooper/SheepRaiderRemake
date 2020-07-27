using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrandonGames.SheepRaiderRemake {
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        // #region Variables
        protected float holdDuration = 0;
        protected bool holdToInteract = false;
        protected bool multipleUse = true;
        protected bool isInteractable = true;
        // #endregion

        // #region Properties
        public float HoldDuration => holdDuration;
        public bool HoldToInteract => holdToInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;
        // #endregion
    
        // #region Methods
        public void Interact()
        {
            Debug.Log($"{gameObject.name}");
        }
        // #endregion
    
    }
}
