using UnityEngine;

namespace Murad
{
    public class PlayerCamera : MonoBehaviour
    {
        //Player Transform.
        public Transform Player;

        //Distance Diffrent.
        Vector3 diff;

        //Camera Follow speed.
        public float FollowSpeed;

        //Current Camera height.
        float CameraHeight;

        //At Start.
        void Start()
        {
            //Set diff to the diffrence of Player position and Camera position.
            diff = transform.position - Player.position;
        }

        //At Every Frame.
        void Update()
        {
            //Player Y value.
            if (Player.position.y > 6f)
            {
                CameraHeight = 6.8f;
            }
            else if (Player.position.y > 2)
            {
                CameraHeight = 3.8f;
            }
            else if (Player.position.y < -6.5f)
            {
                CameraHeight = -6.5f;
            }
            else if (Player.position.y < -2.1f)
            {
                CameraHeight = -4.5f;
            }
            else
            {
                CameraHeight = 0;
            }

            //Set New Camera postion.
            Vector3 desiredPosition = new Vector3(Player.position.x, CameraHeight, -10);

            //Set New Camera Move postion.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, FollowSpeed * Time.deltaTime);

            //Set Camera position to the new postion.
            transform.position = smoothedPosition;
        }
    }
}