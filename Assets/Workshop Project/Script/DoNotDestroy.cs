using UnityEngine;

namespace Murad
{
    public class DoNotDestroy : MonoBehaviour
    {
        //At Start Execution.
        void Awake()
        {
            //Get List of gameobjects the Tag is Music.
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

            //gameobjects Num is more than 1
            if (objs.Length > 1)
            {
                //Destroy this gameObject.
                Destroy(this.gameObject);
            }
            else
            {
                //Dont Destroy this gameObject when loading any scene.
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}