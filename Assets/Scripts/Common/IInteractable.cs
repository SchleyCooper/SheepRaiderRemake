using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrandonGames.SheepRaiderRemake {
    public interface IInteractable
    {
        float HoldDuration { get; }
        bool HoldToInteract { get; }
        bool MultipleUse { get; }
        bool IsInteractable { get; }
    
        void Interact();
    }
}
