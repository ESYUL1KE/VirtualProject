using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Animator anim;
    public Transform firePotision; // �ѱ� ��ġ

    public LineRenderer bulletLine;

    public int MaxAmmo = 12; // �ִ� ź�� ��
    public float cooldownTime = 0.3f; // �߻� ������ ����
    public float reloadTime = 2.0f; // ������ �ð�
    public float fireDistance = 100; // ��Ÿ�
    public float damage = 10;

    private enum State { Ready, Empty, Reload };

    State currentState = State.Empty;

    private float lastFireTime; // ������ �߻� ����
    private int currentAmmo = 0;

    void Start()
    {
        currentState = State.Empty;
        lastFireTime = 0;

        bulletLine.positionCount = 2;
        bulletLine.enabled = false;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if(currentState == State.Ready && Time.time >= lastFireTime + cooldownTime)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }


    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = firePotision.position + firePotision.forward * fireDistance;

        if(Physics.Raycast(firePotision.position, firePotision.forward, out hit, fireDistance))
        {
            //hit.collider
        }
    }

}
