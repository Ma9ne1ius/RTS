
using System;
using System.Collections.Generic;

namespace Units
{
    public class Turret 
    {
        private Type[] allowedTargetTypes;
        public float? rotationSpeed { get; private set; }
        public float? attackWindow { get; private set; }
        public float reloadTime { get; private set; }
        public float? spread { get; private set; }
        public bool isRotationLocked { get; private set; }
        private Ammo ammo { get; set; } = new Ammo(0,0,0, null);
        public Dictionary<Unit, int?> prioritiesToUnits { get; private set; }
        public Dictionary<Unit, float?> baffsToUnits { get; private set; }


    }
}