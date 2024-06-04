using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    public string gunName;  // 이름
    public float range;     // 사정 거리
    public float accuracy;  // 정확도
    public float fireRate;  // 연사 속도 / 한발과 한발간의 시간
    public float reloadTime;// 재장전 속도

    public int damage;      // 공격력

    public int reloadBulletCount;   // 총의 재장전 개수 / 재장전 할 때 몇 발씩 될지
    public int currentBulletCount;  // 현재 탄창 총알 개수
    public int maxBulletCount;      // 총알 최대 보유 개수
    public int carryBulletCount;    // 현재 총 바깥에서 소유하고 있는 총알의 총 개수

    public float retroActionForce;  // 반동 세기. 총의 종류마다 다름.
    public float retroActionFineSightForce; // 정조준시 반동 세기. 총의 종류마다 다름.

    public Vector3 findSightOriginPos;  // 정조준시 총이 향할 위치. 정조준 할 때 총의 위치가 변하니까 그 때의 위치!

    public Animator anim;   // 총의 애니메이션을 재생할 애니메이터 컴포넌트
    public ParticleSystem muzzleFlash;  // 화염구 이펙트 재생을 담당할 파티클 시스템 컴포넌트
    public AudioClip fire_Sound;    // 총 발사 소리 오디오 클립
}
