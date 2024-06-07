using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    [SerializeField]
    public Gun currentGun;

    private float currentFireRate; // 발사와 발사 사이의 시간

    public Transform firePosition; // 총구 위치

    private RaycastHit hitInfo;

    private AudioSource audioSource;  // 발사 소리

    private LineRenderer lineRenderer;  // 레이캐스트 시각화를 위한 라인 렌더러

    private InputAction triggerAction; // 오른쪽 컨트롤러의 트리거 액션

    void Start()
    {
        triggerAction = inputActionAsset.actionMaps[5].actions[2];
        triggerAction.Enable();
    }

    void Update()
    {
        var rightContTrigger = triggerAction.ReadValue<float>();

        GunFireRateCalc();
        TryFire(rightContTrigger);
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;  // 1초에 1씩 감소시킨다.
    }

    private void TryFire(float triggerValue)  // 발사 입력을 받음
    {
        if (triggerValue > 0.1f && currentFireRate <= 0)  // 0.1은 노이즈를 걸러내기 위한 임계값
        {
            Fire();
        }
    }

    private void Fire()  // 발사를 위한 과정
    {
        currentFireRate = currentGun.fireRate;
        Shoot();
    }

    private void Shoot()  // 실제 발사 되는 과정
    {
        // 발사 처리
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate;  // 연사 속도 재계산
        //PlaySE(currentGun.fire_Sound);
        //currentGun.muzzleFlash.Play();

        // 피격 처리
        Hit();
    }

    private void Hit()
    {
        // 총구 위치에서 레이캐스트 발사
        Vector3 rayOrigin = firePosition.position;
        Vector3 rayDirection = firePosition.TransformDirection(firePosition.forward * 10);
        if (Physics.Raycast(firePosition.transform.position, rayDirection, out hitInfo, currentGun.range))
        {
            Debug.Log(hitInfo.transform.name);
            Debug.DrawLine(firePosition.transform.position, hitInfo.point, Color.red, 1.0f);  // 레이 원점에서 히트 포인트까지 빨간색 선을 그림
        }
        else
        {
            Debug.DrawLine(firePosition.position, rayDirection + firePosition.transform.forward * currentGun.range, Color.red, 1.0f);  // 레이 원점에서 최대 거리까지 빨간색 선을 그림
        }
    }

    private void PlaySE(AudioClip _clip)  // 발사 소리 재생
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
