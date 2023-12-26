using UnityEngine;

namespace Murad
{
    public class EnemyManager : MonoBehaviour
    {
        //Enemy RigidBody.
        Rigidbody2D rb;

        //Enemy Movement Speed.
        public int MovementSpeed;

        //Enemy Current Move Direction.
        public bool GoRight;

        //Right Movement Value.
        Vector2 MoveRight;

        //Left Movement Value.
        Vector2 MoveLeft;

        //Left Look Scale.
        Vector2 ScaleLeft = new Vector2(-1, 1);

        //At Start.
        void Start()
        {
            //Set Current object Rigidbody2D to rb.
            rb = GetComponent<Rigidbody2D>();
        }

        //At Every Frame.
        void Update()
        {
            //Update Move Right value to the current Y axis velocity.
            MoveRight = new Vector2(MovementSpeed, rb.velocity.y);

            //Update Move Left value to the current Y axis velocity.
            MoveLeft = new Vector2(-MovementSpeed, rb.velocity.y);

            //GoRight is true.
            if (GoRight)
            {
                //Set RigidBody velocity to MoveRight.
                rb.velocity = MoveRight;
            }
            else
            {
                //Set RigidBody velocity to MoveLeft.
                rb.velocity = MoveLeft;
            }
        }

        //On Collider Enter.
        void OnTriggerEnter2D(Collider2D obj)
        {
            //Collide object tag is EnemyArea.
            if (obj.gameObject.tag == "EnemyArea")
            {
                //GoRight is true.
                if (GoRight)
                {
                    //Set GoRight to false.
                    GoRight = false;

                    //Set object Scale to ScaleLeft.
                    transform.localScale = ScaleLeft;
                }
                else
                {
                    //Set GoRight to true.
                    GoRight = true;

                    //Set object Scale to (1,1).
                    transform.localScale = Vector2.one;
                }
            }
        }
    }
}