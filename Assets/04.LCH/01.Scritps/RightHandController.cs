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

    // �÷��� ����Ʈ Ȱ��ȭ �� ��Ȱ��ȭ
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

    // ������ A ��ư�� ������ �� ȣ��Ǵ� �޼ҵ�
    public void OnPrimaryButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // A ��ư�� ������ �� �÷��ö���Ʈ�� ���¸� ����
            ToggleFlashlight();
        }
    }


    // ���� �ʴ� �ݹ� �Լ�
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
