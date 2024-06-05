using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Right : MonoBehaviour
{
    private InputDevice targetDevice;

    void Start()
    {
        // Ư�� ��Ʈ�ѷ��ϳ��� �������� ���
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics =
            InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
            targetDevice = devices[0];
    }

    void Update()
    {
        /**
         * Boolean: ��ư ���� ����
         * Float: Axis Range 0 ~ 1
         * Vector2: Touchpad ������ -1 ~ 1
         */
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
            Debug.Log("Pressing primary button");

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1F)
            Debug.Log("Trigger pressed " + triggerValue);


        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
    }
}
