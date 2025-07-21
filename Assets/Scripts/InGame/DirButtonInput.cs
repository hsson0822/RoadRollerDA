using UnityEngine;

public class DirButtonInput : MonoBehaviour
{
    public float buttonValue; // -1 ¶Ç´Â 1
    private bool isPressed = false;

    public void OnButtonDown()
    {
        Debug.Log("Down");
        isPressed = true;
    }

    public void OnButtonUp()
    {
        Debug.Log("Up");
        isPressed = false;
    }

    public float GetValue()
    {
        return isPressed ? buttonValue : 0f;
    }
}
