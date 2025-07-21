using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public enum ControlType
{
    JOYSTICK,
    BUTTON,
    HANDLE,
}

public class ControllerUI : MonoBehaviour
{
    [SerializeField] GameObject Joystick;
    [SerializeField] GameObject Buttons;

    private void OnEnable()
    {
        switch (GameManager.Instance.controlType)
        {
            case ControlType.JOYSTICK:
                Buttons.SetActive(false);
                break;

            case ControlType.BUTTON:
                Joystick.SetActive(false);
                break;

            case ControlType.HANDLE:
                Buttons.SetActive(false);
                Joystick.SetActive(false);
                break;

            default:
                Buttons.SetActive(false);
                break;
        }

    }

    private void OnDisable()
    {

    }
}
