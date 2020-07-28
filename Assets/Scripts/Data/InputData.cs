using UnityEngine;

namespace BrandonGames.SheepRaiderRemake.Data
{
    [CreateAssetMenu(fileName = "InputData", menuName = "Data/Input/InputData", order = 0)]
    public class InputData : ScriptableObject
    {
        [SerializeField]
        private InputConfiguration inputConfig;

        // #region Variables
        private Vector3 joystick1, joystick2, joystick3;
        private Vector2 directional1, directional2;
        private float button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12;
        // #endregion

        // #region Properties
        public Vector3 Joystick1 => joystick1;
        public Vector3 Joystick2 => joystick2;
        public Vector3 Joystick3 => joystick3;
        public Vector2 Directional1 => directional1;
        public Vector2 Directional2 => directional2;
        public float Button1 => button1;
        public float Button2 => button2;
        public float Button3 => button3;
        public float Button5 => button4;
        public float Button6 => button5;
        public float Button7 => button6;
        public float Button8 => button7;
        public float Button9 => button8;
        public float Button10 => button10;
        public float Button11 => button11;
        public float Button12 => button12;
        // #endregion

        public void ProcessInput()
        {
            joystick1.x = Input.GetAxis(inputConfig.directional1);
            joystick1.y = Input.GetAxis(inputConfig.directional2);
            joystick2.x = Input.GetAxis(inputConfig.directional3);
            joystick2.y = Input.GetAxis(inputConfig.directional4);

            button1 = Input.GetAxis(inputConfig.faceButtonSouth);
            button2 = Input.GetAxis(inputConfig.faceButtonEast);
            button3 = Input.GetAxis(inputConfig.faceButtonWest);
            button4 = Input.GetAxis(inputConfig.faceButtonNorth);
        }

        public void SetNewConfiguration(InputConfiguration newInputConfig)
        {
            if (newInputConfig && inputConfig != newInputConfig)
            {
                inputConfig = newInputConfig;
            }
        }
    }
}