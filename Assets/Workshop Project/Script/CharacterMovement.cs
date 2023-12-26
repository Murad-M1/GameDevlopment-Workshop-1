using UnityEngine;
using UnityEngine.UI;

namespace Murad
{
    public class CharacterMovement : MonoBehaviour
    {
        //Game Mode Manager Script.
        public GameMode GameMode_Script;

        //Lose UI Panel.
        public GameObject LosePanel;

        //Transform for the Player Ground Level.
        public Transform GroundCheck;

        //Player Stand Platforms Layer.
        public LayerMask GroundLayer;

        //Player States Booleans.
        public bool isMoving;
        public bool isJumping;
        public bool isGrounded;
        public bool isDamaged;
        public bool InvertController;

        //Player Movement Speed.
        public float MovementSpeed = 1;

        //Player Jump Force.
        public float JumpForce = 5;

        //Events Sound Effect.
        public AudioSource JumpSfx;
        public AudioSource LoseSfx;

        //UI Death Score Display Text.
        public Text DeathScoreText;

        //Player Death Count.
        int DeathCount;

        //Player RigidBody.
        Rigidbody2D rb;

        //Player Animator.
        Animator animator;

        //Right Movement Value.
        Vector2 MoveRight;

        //Left Movement Value.
        Vector2 MoveLeft;

        //Left Look Scale.
        Vector2 ScaleLeft = new Vector2(-1, 1);

        //One Time Execution bool.
        bool oneTime;

        //UI Controllers Movement Request.
        int movementCode = 0;

        //UI Controllers Jump Request.
        int JumpCode = 0;

        //Ar Start.
        void Start()
        {
            //Set Current object Rigidbody2D to rb.
            rb = GetComponent<Rigidbody2D>();

            //Set Current object Animator to animator.
            animator = GetComponent<Animator>();
        }

        //At Every Frame.
        void Update()
        {
            //is Player Damaged is false.
            if (!isDamaged)
            {
                //Update Move Right value to the current Y axis velocity.
                MoveRight = new Vector2(MovementSpeed, rb.velocity.y);

                //Update Move Left value to the current Y axis velocity.
                MoveLeft = new Vector2(-MovementSpeed, rb.velocity.y);

                //Input Keyboard Left Arrow or Cntrollers Movement Value is 2.
                if (Input.GetKey(KeyCode.LeftArrow) || movementCode == 2)
                {
                    //Set isMoving to true.
                    isMoving = true;

                    //InvertController is true
                    if (InvertController)
                    {
                        //Set Player Velocity to MoveRight.
                        rb.velocity = MoveRight;

                        //Set object Scale to (1,1).
                        transform.localScale = Vector2.one;
                    }
                    else
                    {
                        //Set Player Velocity to MoveLeft.
                        rb.velocity = MoveLeft;

                        //Set object Scale to ScaleLeft.
                        transform.localScale = ScaleLeft;
                    }
                }
                //Input Keyboard Right Arrow or Cntrollers Movement Value is 1.
                else if (Input.GetKey(KeyCode.RightArrow) || movementCode == 1)
                {
                    //Set isMoving to true.
                    isMoving = true;

                    //InvertController is true
                    if (InvertController)
                    {

                        //Set Player Velocity to MoveLeft.
                        rb.velocity = MoveLeft;

                        //Set object Scale to ScaleLeft.
                        transform.localScale = ScaleLeft;
                    }
                    else
                    {
                        //Set Player Velocity to MoveRight.
                        rb.velocity = MoveRight;

                        //Set object Scale to (1,1).
                        transform.localScale = Vector2.one;
                    }
                }
                else
                {
                    //Set isMoving to false.
                    isMoving = false;

                    //Set Player Velocity to idle.
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                }


                //Check if GroundCheck Object is near Platform with GroundLayer Layer.
                if (Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.05f, GroundLayer))
                {
                    //Set isJumping to false.
                    isJumping = false;

                    //Set isGrounded to true.
                    isGrounded = true;

                    //Input Keyboard Upper Arrow or Cntrollers Movement Value is 1.
                    if (Input.GetKeyDown(KeyCode.UpArrow) || JumpCode == 1)
                    {
                        //Set Player Velocity to (0, 1) by JumpForce.
                        rb.velocity = Vector2.up * JumpForce;

                        //Play JumpSfx Sound.
                        JumpSfx.Play();
                    }
                }
                else
                {
                    //Set isJumping to true.
                    isJumping = true;

                    //Set isGrounded to false.
                    isGrounded = false;
                }


                //isGrounded is true
                if (isGrounded)
                {
                    //isMoving is true
                    if (isMoving)
                    {
                        //Play Player_Walk Animation.
                        animator.Play("Player_Walk");
                    }
                    //isMoving is false and isJumping is false.
                    else if (!isMoving && !isJumping)
                    {
                        //Play Player_Idle Animation.
                        animator.Play("Player_Idle");
                    }
                }
                else
                {
                    //isJumping is true
                    if (isJumping)
                    {
                        //Play Player_Jump Animation.
                        animator.Play("Player_Jump");
                    }
                }
            }
            else //Player Damaged.
            {
                //oneTime is false.
                if (!oneTime)
                {
                    //Set oneTime to true.
                    oneTime = true;

                    //Play JumpSfx Sound.
                    LoseSfx.Play();

                    //Play Player_Damaged Animation.
                    animator.Play("Player_Damaged");

                    //Set Player Velocity to (0, 1) by JumpForce.
                    rb.velocity = Vector2.up * JumpForce;

                    //EasyGame at GameMode_Script is true.
                    if (GameMode_Script.EasyGame)
                    {
                        //Call respawnPlayer Method after 0.8 Sec.
                        Invoke("respawnPlayer", 0.8f);
                    }
                    else
                    {
                        //Disable Player BoxCollider2D.
                        GetComponent<BoxCollider2D>().enabled = false;

                        //Disable PlayerCamera at Main Scene Camera.
                        Camera.main.GetComponent<PlayerCamera>().enabled = false;

                        //Call respawnPlayer Method after 2 Sec.
                        Invoke("LateLosePanelShow", 2);
                    }
                }
            }
        }

        //Respawn Player.
        void respawnPlayer()
        {
            //Increase DeathCount.
            DeathCount++;

            //Update New death Cound in DeathScore UI Text.
            DeathScoreText.text = "" + DeathCount;

            //Set isDamaged to false.
            isDamaged = false;

            //Set Player position to Upper Right posetion.
            transform.position = new Vector2(transform.position.x + 3, transform.position.y + 3);

            //Set oneTime to false.
            oneTime = false;
        }

        //Handle UI Movement Controllers Buttons.
        public void UserInterfaceMovementButtons(int req)
        {
            //Go Right 1.
            //Go Left 2.
            //Go Idle 3.

            //Set movementCode to req.
            movementCode = req;
        }

        //Handle UI Jump Controller Button.
        public void UserInterfaceJumpButton(int req)
        {
            //Jump 0.
            //Idle 1.

            //Set JumpCode to req.
            JumpCode = req;
        }

        //Late Lose Panel Activate.
        void LateLosePanelShow()
        {
            //Set LosePanel Active State to true.
            LosePanel.SetActive(true);
        }
    }
}