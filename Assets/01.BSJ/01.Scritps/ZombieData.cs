using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "ScriptableObject/ZombieData", order = 1)]
public class ZombidData : ScriptableObject
{
    public int Hp;
    public int MaxHp = 100;
    public int Damage;
    public int Speed;
    public int DetectionRagne;
    public int AttackRange;
}