using Units;
using UnityEngine;

namespace Units
{
    #nullable enable
    public class Ammo : MonoBehaviour
    {
        public float currentAmmo ;
        public float resupplyAmmo ;
        public float maxAmmo ;
        public Projectile? projectile ;
        public Ammo(float currentAmmo, float resupplyAmmo, float maxAmmo, Projectile projectile)
        {
            this.currentAmmo = currentAmmo;
            this.resupplyAmmo = resupplyAmmo;
            this.maxAmmo = maxAmmo;
            this.projectile = projectile;
        }

    }


    public abstract class Projectile : MonoBehaviour
    {
        public float damage ;
        public float? damageRange ;
        public float chanceToPenetration ;

        protected Projectile(float damage, float? damageRange, float chanceToPenetration)
        {
            this.damage = damage;
            this.damageRange = damageRange;
            this.chanceToPenetration = chanceToPenetration;
        }

    }

}