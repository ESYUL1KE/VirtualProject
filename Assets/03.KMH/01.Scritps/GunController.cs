using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    public Gun currentGun;

    private float currentFireRate; // 발사와 발사 사이의 시간

    public Transform firePosition; // 총구 위치

    private RaycastHit hitInfo;

    private AudioSource audioSource;  // 발사 소리


    void Update()
    {
/*        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawLine(firePosition.transform.position, Vector3.forward * 5, Color.blue, 3f);
        }*/

        GunFireRateCalc();
        TryFire();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;  // 1초에 1씩 감소시킨다.
    }

    private void TryFire()  // 발사 입력을 받음
    {
        if (Input.GetButton("Fire1") && currentFireRate <= 0)
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
            Debug.DrawRay(firePosition.transform.position, hitInfo.point, Color.red, 1.0f);  // 레이 원점에서 히트 포인트까지 빨간색 선을 그림
        }
        else
        {
            Debug.DrawRay(firePosition.position, rayDirection + firePosition.transform.forward * currentGun.range, Color.red, 1.0f);  // 레이 원점에서 최대 거리까지 빨간색 선을 그림
        }
    }

    private void PlaySE(AudioClip _clip)  // 발사 소리 재생
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
