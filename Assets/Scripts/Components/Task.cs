using System;
using UnityEngine;

#nullable enable
namespace Units
{
    public class Task : MonoBehaviour
    {
        public Unit? targetUnit;
        public Vector3? targetPosition;
        public Action? methodWithPosition;
        public Action? methodWithUnit;
        public bool isCyclic;
        public bool? isCompleted;
        public Task(Action? methodWithPosition, Vector3? targetPosition, Unit? targetUnit,  Action? methodWithUnit)
        {
            this.targetUnit = targetUnit;
            this.methodWithUnit = methodWithUnit;
            this.targetPosition = targetPosition;
            this.methodWithPosition = methodWithPosition;
            isCompleted = false;
        }

        public Task task (Vector3 targetPosition, Action methodWithPosition)
        {
            return new Task(methodWithPosition, targetPosition, null, null);
        }
        public Task task (Unit targetUnit,  Action methodWithUnit)
        {
            return new Task(null,null, targetUnit, methodWithUnit);
        }
        public void Execute()
        {
            if (targetUnit != null)
            {
                methodWithUnit?.DynamicInvoke(targetUnit);
            }
            else
            {
                methodWithPosition?.DynamicInvoke(targetPosition);
            }
        }
        private void Update()
        {
            if (GetComponent<Unit>().Tasks.Count == 0) return;
            Task currentTask = GetComponent<Unit>().Tasks.Peek();
            currentTask.Execute();
            if ((bool)currentTask.isCompleted) GetComponent<Unit>().Tasks.Dequeue();
        }
    }
}