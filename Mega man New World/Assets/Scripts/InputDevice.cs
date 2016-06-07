using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InputDevice : MonoBehaviour {

    public bool XboxController;
    public bool KeyBoard;

    public void Xbox()
    {
        XboxController = true;
        SceneManager.LoadScene("FrontEnd");
    }
    public void Keyboard()
    {
        //SceneManager.LoadScene("FrontEnd");
        KeyBoard = true;
    }
    void Update()
    {
        if(XboxController == true)
        {
            print("XboxController was picked");
        }
    }
}
