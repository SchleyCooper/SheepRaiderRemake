using System;
using BrandonGames.SheepRaiderRemake.Data;
using UnityEngine;

namespace BrandonGames.SheepRaiderRemake {
    public class InputController : MonoBehaviour {
        
        private int playerIdx = 0;
        public int PlayerIdx => playerIdx;
    
        [SerializeField]
        private InputData inputData;
        public InputData InputData => inputData;
    
        private void Update() {
            GetInput();
        }
    
        private void GetInput()
        {
            if (inputData)
            {
                inputData.ProcessInput();
            }
        }

        public void SetPlayerIdx(int newIdx)
        {
            if (playerIdx != newIdx)
            {
                playerIdx = newIdx;
            }
        }

        public void SetPlayerInput(InputData newInputData, InputConfiguration newInputConfig = null)
        {
            if (newInputData && inputData != newInputData)
            {
                inputData = newInputData;
                if(newInputConfig) {
                    inputData.SetNewConfiguration(newInputConfig);
                }
            }
        }
    }
}