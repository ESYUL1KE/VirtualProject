using Action;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightHandController : MonoBehaviour, XRIDefaultInputActions.IXRIRightHandActions
{
    private XRIDefaultInputActions controls;

    [SerializeField] private GameObject flashlight;
    private bool flashlightActive = false;

    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new XRIDefaultInputActions();
            controls.XRIRightHand.SetCallbacks(this);
        }

        controls.XRIRightHand.Enable();
    }

    void Start()
    {
        flashlight.SetActive(false);
    }

    // 플래쉬 라이트 활성화 및 비활성화
    private void ToggleFlashlight()
    {
        if (!flashlightActive)
        {
            flashlight.SetActive(true);
            flashlightActive = true;
        }
        else
        {
            flashlight.SetActive(false);
            flashlightActive = false;
        }
    }

    // 오른쪽 A 버튼이 눌렸을 때 호출되는 메소드
    public void OnPrimaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // A 버튼이 눌렸을 때 플래시라이트의 상태를 변경
            ToggleFlashlight();
        }
    }


    // 쓰지 않는 콜백 함수
    public void OnAimFlags(InputAction.CallbackContext context) { }
    public void OnAimPosition(InputAction.CallbackContext context) { }
    public void OnAimRotation(InputAction.CallbackContext context) { }
    public void OnGripPosition(InputAction.CallbackContext context) { }
    public void OnGripRotation(InputAction.CallbackContext context) { }
    public void OnHapticDevice(InputAction.CallbackContext context) { }
    public void OnIsTracked(InputAction.CallbackContext context) { }
    public void OnPinchPosition(InputAction.CallbackContext context) { }
    public void OnPokePosition(InputAction.CallbackContext context) { }
    public void OnPokeRotation(InputAction.CallbackContext context) { }
    public void OnPosition(InputAction.CallbackContext context) { }
    public void OnRotation(InputAction.CallbackContext context) { }
    public void OnSecondaryButtonPress(InputAction.CallbackContext context) { }
    public void OnTrackingState(InputAction.CallbackContext context) { }
}
