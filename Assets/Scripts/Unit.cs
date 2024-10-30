using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Units
{
    #nullable enable
    public abstract class Unit
    {
        public string team { get; private set; }
        public string state { get; private set; }
        public float rangeOfView { get; private set; }
        public List<Task> Tasks { get; private set; }
        public Health health{ get; private set; }
        
        
        protected virtual void Assist()
        {
            // TODO: Implement assist logic
        }
    }
}