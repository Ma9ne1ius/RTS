using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;
namespace Units
{
#nullable enable
    public class Infantry : Unit, IMovingOnFoot, IAttackable
    {

        public Infantry(Player player, Vector3 position, string team, string state, float rangeOfView, Queue<Task> Tasks, ExperienceComponent Experience, ShieldFieldComponent shieldField, TurretComponent turret, MaterialComponent material, EnergyComponent energy, float speed, float rotationSpeed, NavMeshAgent agent) : base(player, state, rangeOfView, Tasks, Experience, shieldField, turret, material, energy)
        {
            this.agent = agent;
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
        }
        public NavMeshAgent agent;

        public float speed;

        public float rotationSpeed;
        

        public Dictionary<Type, int?>? prioritiesToUnits;


        public void MoveTo(Vector3 targetPosition)
        {
            if (agent != null)
            {
                agent.SetDestination(targetPosition);
            }

        }

        public void TakeDamage(float damage)
        {
            // TODO: логика получения урона
        }
    }
}