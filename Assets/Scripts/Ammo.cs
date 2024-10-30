using Units;
using UnityEngine;

namespace Units
{
    #nullable enable
    public class Ammo
    {
        public float currentAmmo { get; private set; }
        public float resupplyAmmo { get; private set; }
        public float maxAmmo { get; private set; }
        public Projectile? typeProjectile { get; private set; }
        public Ammo(float currentAmmo, float resupplyAmmo, float maxAmmo, Projectile typeProjectile)
        {
            this.currentAmmo = currentAmmo;
            this.resupplyAmmo = resupplyAmmo;
            this.maxAmmo = maxAmmo;
            this.typeProjectile = typeProjectile;
        }

    }


    public abstract class Projectile
    {
        public float damage { get; private set; }
        public float? damageRange { get; private set; }
        public float chanceToPenetration { get; private set; }

        protected Projectile(float damage, float? damageRange, float chanceToPenetration)
        {
            this.damage = damage;
            this.damageRange = damageRange;
            this.chanceToPenetration = chanceToPenetration;
        }


    }

