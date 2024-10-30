using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class Energy
    {
        public float energyCost { get; private set; }
        public float? energyBalance { get; private set; }
        public float? energyStorage { get; private set; }

    }
}