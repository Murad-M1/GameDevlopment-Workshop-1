using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Murad
{
    public class PauseMenuManager : MonoBehaviour
    {
        //UI Phone Controller Buttons.
        public GameObject ControllerButtons;

        //UI Controllrt Toggle
        public Toggle UseUserInterfaceControllersToggle;

        //Use Phone UI Controllers.
        public bool UseUserInterfaceControllers;

        //At Start.
        void Start()
        {
            //Current scene name is not Menu.
            if (!SceneManager.GetActiveScene().name.Equals("Menu"))
            {
                //Set UI Controllers Toggle value to Use UI Phone Controllers.
                UseUserInterfaceControllersToggle.isOn = UseUserInterfaceControllers;

                //Set UI Controllers Active state to Use UI Phone Controllers.
                ControllerButtons.SetActive(UseUserInterfaceControllers);
            }
        }

        //Handle UI Buttons requests.
        public void MenuButtons(int req)
        {
            //Set Time to 1.
            Time.timeScale = 1;

            //Request equal 0.
            if (req == 0)//Pause.
            {
                //Set Time to 0.
                Time.timeScale = 0;
            }
            else if (req == 1)//Resume.
            {
                //Set UI Controllers Active state to Use UI Phone Controllers.
                ControllerButtons.SetActive(UseUserInterfaceControllers);
            }
            else if (req == 2)//Load Game Scene.
            {
                //Load Game Scene.
                SceneManager.LoadScene("Game");
            }
            else if (req == 3)//Load Menu.
            {
                //Load Menu Scene.
                SceneManager.LoadScene("Menu");
            }
            else if (req == 4)//Exit App.
            {
                //Quit Application.
                Application.Quit();
            }
        }

        //Change Use Controllers Value.
        public void UserInterfaceControllers()
        {
            //Set Use UI Phone Controllers to UI Controllers Toggle value.
            UseUserInterfaceControllers = UseUserInterfaceControllersToggle.isOn;
        }
    }
}