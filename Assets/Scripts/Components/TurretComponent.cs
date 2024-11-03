
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    #nullable enable
    public class TurretComponent : MonoBehaviour , IAttackingByBranchOf
    {
        public float? rotationSpeed ;
        public Vector2? attackWindow ;
        public float reloadTime ;
        public float? spread ;
        private Ammo ammo ;
        public Dictionary<Type, int?>? prioritiesToType ;
        public Dictionary<Type, float>? buffsToTypes ;
        // public Task task ;
        public TurretComponent(float? rotationSpeed, Vector2? attackWindow, float reloadTime, float? spread, Ammo ammo, Dictionary<Type, int?> prioritiesToType, Dictionary<Type, float> buffsToTypes)
        {
            this.rotationSpeed = rotationSpeed;
            this.attackWindow = attackWindow;
            this.reloadTime = reloadTime;
            this.spread = spread;
            this.ammo = ammo;
            this.prioritiesToType = prioritiesToType;
            this.buffsToTypes = buffsToTypes;
        }

        public void targeting(Vector3 targetPosition)
        {
            // TODO: логика нацеливания
        }
        public void targeting(Unit unit)
        {
            // TODO: логика нацеливания на юнит
        }
        public void fire()
        {
            // TODO: логика огня
        }

        public void Attack(Vector3 targetPosition)
        {
            targeting(targetPosition);
            fire();
        }

        public void Attack(Unit targetUnit)
        {
            targeting(targetUnit);
            fire();
        }
    }
}