using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class MaterialComponent: MonoBehaviour
    {
        public float MaterialComponentCost ;
        public float? MaterialComponentBalance ;
        public float? MaterialComponentStorage ;

        public MaterialComponent(float MaterialComponentCost, float? MaterialComponentBalance, float? MaterialComponentStorage)
        {
            this.MaterialComponentCost = MaterialComponentCost;
            this.MaterialComponentBalance = MaterialComponentBalance;
            this.MaterialComponentStorage = MaterialComponentStorage;
        }
    }
}
