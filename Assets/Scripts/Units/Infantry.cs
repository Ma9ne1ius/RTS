using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Units
{
    #nullable enable
    public class Infantry : Unit, IMovingOnFoot, IAttackable
    {
        public Infantry(Player player,Vector3 position, string team, string state, float rangeOfView, Queue<Task> Tasks, ExperienceComponent Experience, ShieldFieldComponent shieldField, TurretComponent turret, MaterialComponent material, EnergyComponent energy, float speed, float rotationSpeed) : base( player, state, rangeOfView, Tasks, Experience, shieldField, turret, material, energy)
        {
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
        }

        public float speed ;

        public float rotationSpeed ;

        public Dictionary<Type, int?>? prioritiesToUnits ;


        public void MoveTo(Vector3 targetPosition)
        {

        }

        public void TakeDamage(float damage)
        {
            // TODO: логика получения урона
        }
    }
}