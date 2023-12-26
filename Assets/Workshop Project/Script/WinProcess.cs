using UnityEngine;

namespace Murad
{
    public class WinProcess : MonoBehaviour
    {
        //Win Audio.
        public AudioSource WinSfx;

        //Win Panel UI.
        public GameObject WinPanel;

        //On Collider Enter.
        void OnTriggerEnter2D(Collider2D Player)
        {
            //Collide object tag is Player.
            if (Player.gameObject.tag == "Player")
            {
                //Get this Animation and play animation.
                gameObject.GetComponent<Animator>().Play("Flag_Win");

                //Play Win Audio.
                WinSfx.Play();

                //Call Method in 2 sec.
                Invoke("WinPanelShow", 2);
            }
        }

        //Active Win Panel.
        void WinPanelShow()
        {
            //Active gameobject.
            WinPanel.SetActive(true);
        }
    }
}