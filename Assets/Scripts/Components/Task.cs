using System;
using UnityEngine;

#nullable enable
namespace Units
{
    public class Task : MonoBehaviour
    {
        public Unit? targetUnit ;
        public Vector3 targetPosition ;
        public Action<Vector3>? methodWithPosition ;
        public Action<Unit>? methodWithUnit ;
        public bool isCyclic ;
        public bool? isCompleted ;
        public Task(Unit? targetUnit, Vector3 targetPosition, Action<Vector3>? methodWithPosition, Action<Unit>? methodWithUnit)
        {
            this.targetUnit = targetUnit;
            this.targetPosition = targetPosition;
            this.methodWithPosition = methodWithPosition;
            this.methodWithUnit = methodWithUnit;
            this.isCompleted = false;
        }
        public void Execute()
        {
            if (targetUnit != null)
            {
                methodWithUnit?.Invoke(targetUnit);
            }
            else
            {
                methodWithPosition?.Invoke(targetPosition);
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