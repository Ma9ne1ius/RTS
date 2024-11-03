using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class ShieldFieldComponent
    {
        public float power ;
        public float? rangeField ;
        public float regenerationPower ;
        public ShieldFieldComponent(float power, float rangeField, float regeneratePower)
        {
            this.power = power;
            this.rangeField = rangeField;
            this.regenerationPower = regeneratePower;
        }
    }
}