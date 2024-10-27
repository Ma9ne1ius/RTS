using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Unit : MonoBehaviour
{
    private float health;
    private float regenerationHealth;
    private string team;
    private float damage;
    private float? rangeOfDamage;
    private float armor;
    private float attackRange;
    private float reloadTime;
    private float? ammo;
    private string state;
    private float rangeOfView;
    private float exp;
    private float chanceToPenetration;
    private float spread;
    private Dictionary<Unit, int> targetsAtDistance;
    private Unit producer;
    private float materyalCost;
    private float energyCost;
    private Dictionary<Unit, Array[2]<int?,float>> prioritiesAndBaffsOfUnits;
}
