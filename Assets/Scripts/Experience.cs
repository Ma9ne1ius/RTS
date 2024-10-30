using System.Collections.Generic;

namespace Units
{
    public class Experience
    {
        public float experience { get; private set; }
        public float? upgradeTime { get; private set; }
        public Dictionary<string, float> BuffsSomeoneField { get; private set; }
    }
}