using UnityEngine;

namespace Murad
{
    public class PrankPlatfromManager : MonoBehaviour
    {
        //Fall when enter.
        public bool ActiveGravity;

        //Late Fall when enter.
        public bool LateActiveGravity;

        //active when collide.
        public bool TouchActive;

        //Increase Player Jump.
        public bool JumpUp;

        //Increase Player Speed.
        public bool SpeedUp;

        //Decrease Player Speed.
        public bool SpeedDown;

        //Invert Controllers.
        public bool ControlInvert;

        //Destroy this object.
        public bool isDestroyed;

        //Late object destroy.
        public bool LateDestroy;

        //On Collider Enter.
        void OnTriggerEnter2D(Collider2D Player)
        {
            //Collide object tag is Player.
            if (Player.gameObject.tag == "Player")
            {
                //Active Gravity is true.
                if (ActiveGravity)
                {
                    //Set object RB constraints to none.
                    gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                    //Set object RB gravity to 1.
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }

                //Late Active Gravity is true.
                if (LateActiveGravity)
                {
                    //Call Method in 2 sec.
                    Invoke("AfterSeconds", 2f);

                    //Exit excution method.
                    return;
                }

                //Touch Active is true.
                if (TouchActive)
                {
                    //Enable object sprite.
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }

                //Jump Up is true.
                if (JumpUp)
                {
                    //Increase Player jump by 2.
                    Player.gameObject.GetComponent<CharacterMovement>().JumpForce += 2;

                    //Set Platform color to white.
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }

                //Control Invert is true.
                if (ControlInvert)
                {
                    //InvertController in Player CharacterMovement is true.
                    if (Player.gameObject.GetComponent<CharacterMovement>().InvertController)
                    {
                        //Set InvertController in Player CharacterMovement to false.
                        Player.gameObject.GetComponent<CharacterMovement>().InvertController = false;
                    }
                    else
                    {
                        //Set InvertController in Player CharacterMovement to true.
                        Player.gameObject.GetComponent<CharacterMovement>().InvertController = true;
                    }

                    transform.GetChild(0).gameObject.SetActive(true);
                }

                //Speed Up is true.
                if (SpeedUp)
                {
                    //Increase Player speed by 1.
                    Player.gameObject.GetComponent<CharacterMovement>().MovementSpeed += 1;

                    //Set Platform color to white.
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }

                //Speed Down is true.
                if (SpeedDown)
                {
                    //Decrease Player speed by 1.
                    Player.gameObject.GetComponent<CharacterMovement>().MovementSpeed -= 1;

                    //Set Platform color to white.
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }

                //isDestroyed is true.
                if (isDestroyed)
                {
                    //LateDestroy is true.
                    if (LateDestroy)
                    {
                        //Destroy this gameObject after 5 sec.
                        Destroy(gameObject, 5);
                    }
                    else
                    {
                        //Destroy this gameObject.
                        Destroy(gameObject);
                    }
                }

                //Destroy this Script.
                Destroy(this);
            }
        }

        //Activate Late Gravity.
        void AfterSeconds()
        {
            //Set object RB constraints to none.
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            //Set object RB gravity to 1.
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;

            //Activate first object children.
            transform.GetChild(0).gameObject.SetActive(true);

            //Destroy this Script.
            Destroy(this);
        }
    }
}