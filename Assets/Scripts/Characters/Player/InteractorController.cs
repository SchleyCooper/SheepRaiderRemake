using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrandonGames.SheepRaiderRemake {
    public class InteractorController : MonoBehaviour
    {
        [SerializeField]
        private float interactDistance = 1.0f;
        [SerializeField]
        private float interactRadius = 1.0f;
        [SerializeField]
        private LayerMask interactableLayers = LayerMask.GetMask("Interactable");   // probably won't change
        
        private RaycastHit hit;

        private IInteractable interactableObject;
        public IInteractable InteractableObject => interactableObject;

        // Update is called once per frame
        void Update()
        {
            CheckForInteractables();
            CheckForInteraction();
        }

        protected void CheckForInteractables()
        {
            // spherecast to grab reference to first interactable in range
            if (Physics.SphereCast(transform.position, interactRadius, transform.forward, out hit, interactDistance, interactableLayers))
            {
                interactableObject = hit.transform.GetComponent<IInteractable>();
            }
        }

        private void CheckForInteraction()
        {
            if (Input.GetKeyDown(KeyCode.E) && interactableObject != null)
            {
                if(interactableObject.IsInteractable) 
                {
                    interactableObject.Interact();
                }
            }
        }
    }
}
