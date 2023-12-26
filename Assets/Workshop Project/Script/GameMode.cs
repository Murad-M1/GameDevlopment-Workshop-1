using UnityEngine;

namespace Murad
{
    public class GameMode : MonoBehaviour
    {
        //Is it East Game Mode.
        public bool EasyGame;

        //At Start.
        void Start()
        {
            //Set Time to 0.
            Time.timeScale = 0f;
        }

        //At Choosing game mode.
        public void SetGameMode(bool val)
        {
            //Set Time to 1.
            Time.timeScale = 1f;

            //Set EasyGame to val.
            EasyGame = val;
        }
    }
}