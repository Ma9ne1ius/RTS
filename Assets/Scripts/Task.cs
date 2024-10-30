using System;
using UnityEngine;

#nullable enable
namespace Units
{
    public class Task 
    {
        public Unit? targetUnit {get; set ;}
        public Vector3 targetPosition {get; set ;}
        public Action<Unit?> methodToExecuteUnit {get; set ;}
        public Action<Vector3> methodToExecuteVector {get; set ;}
        public bool? isCompleted {get; private set; }
        public void TaskMethodToExecute()
        {
            if (targetUnit != null)
            {
                methodToExecuteUnit?.Invoke(targetUnit);
            }
            else
            {
                methodToExecuteVector?.Invoke(targetPosition);
            }
        }

    }
}