using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class ExperienceComponent: MonoBehaviour
    {
        #nullable enable
        public float experience ;
        public float? upgradeTime ;
        public Dictionary<string, float>? BuffsSomeoneField ;
        public ExperienceComponent(float experience, float? upgradeTime, Dictionary<string, float> BuffsSomeoneField)
        {
            this.experience = experience;
            this.upgradeTime = upgradeTime;
            this.BuffsSomeoneField = BuffsSomeoneField;
        }
    }
}