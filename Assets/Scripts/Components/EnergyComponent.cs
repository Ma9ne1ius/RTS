using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class EnergyComponent: MonoBehaviour
    {
        public float EnergyComponentCost ;
        public float? EnergyComponentBalance ;
        public float? EnergyComponentStorage ;

        public EnergyComponent(float EnergyComponentCost, float? EnergyComponentBalance, float? EnergyComponentStorage)
        {
            this.EnergyComponentCost = EnergyComponentCost;
            this.EnergyComponentBalance = EnergyComponentBalance;
            this.EnergyComponentStorage = EnergyComponentStorage;
        }

    }
}