using UnityEngine;

namespace BrandonGames.SheepRaiderRemake.Data
{
    [CreateAssetMenu(fileName = "InputConfiguration", menuName = "Data/Input/InputConfiguration", order = 0)]
    public class InputConfiguration : ScriptableObject {
        public string faceButtonNorth, faceButtonSouth, faceButtonWest, faceButtonEast, faceButton1, faceButton2;
        public string buttonLeft0, buttonLeft1, buttonLeft2, buttonLeft3, buttonRight0, buttonRight1, buttonRight2, buttonRight3;
        public string systemButton1, systemButton2, systemButton3;
        public string directional1, directional2, directional3, directional4, directional5, directional6;

    }
}