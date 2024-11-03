using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class Missile : Projectile, IMissileMoving
    {
        public float speed ;

        public Missile(float damage, float? damageRange, float chanceToPenetration, float speed) : base(damage, damageRange, chanceToPenetration)
        {
            this.speed = speed;
        }
        
        public float rotationSpeed ;

        public void MoveTo(Vector3 targetPosition)
        {
            
        }
    }
}