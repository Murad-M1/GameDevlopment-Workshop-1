using UnityEngine;

namespace Murad
{
    public class KillCharacter : MonoBehaviour
    {
        //On Collider Enter.
        public void OnTriggerEnter2D(Collider2D Player)
        {
            //Collide object tag is Player.
            if (Player.gameObject.tag == "Player")
            {
                //Set isDamaged in Player CharacterMovement to true.
                Player.GetComponent<CharacterMovement>().isDamaged = true;
            }
        }
    }
}
