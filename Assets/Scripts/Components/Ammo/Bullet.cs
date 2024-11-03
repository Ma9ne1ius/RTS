using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class Bullet : Projectile, IProjectileMoving
    {
        public float speed ;

        public Bullet(float damage, float? damageRange, float chanceToPenetration, float speed) : base(damage, damageRange, chanceToPenetration)
        {
            this.speed = speed;
        }
        
        public float rotationSpeed ;

        public void MoveTo(Vector3 targetPosition)
        {
            
        }
    }
}