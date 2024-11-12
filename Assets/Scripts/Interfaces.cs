using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Units
{
    public interface IAttackable
    {
        void TakeDamage(float damage);
    }
#nullable enable
    public interface IAttacking
    {
        // Unit? targetUnit { get; }
        // Vector3 targetPosition { get; }
        void Attack(Vector3 targetPosition);
        void Attack(Unit targetUnit);
    }

    public interface IMovable
    {

        // float speed { get; }
        // float rotationSpeed { get; }
        void MoveTo(Vector3 targetPosition);
    }

    public interface IBehaviorStrategy
    {
        void ExecuteBehavior(Unit unit);
    }
    public interface ISelectable
    {
        void Select();
        void Deselect();
        // bool IsSelected { get; }
    }
    public interface IAreaEffect
    {
        // float EffectRadius { get; }
        void ApplyEffect(Unit unit);
    }
    public interface IStealth
    {
        void Cloak();
        void Decloak();
        // bool IsCloaked { get; }
    }
    public interface IUpgradeable
    {
        void Upgrade();
        // float UpgradeValue { get; }
    }
    public interface IBuildable
    {
        // float BuildCost { get; }
        // float BuildTime { get; }
        void OnBuildComplete();
    }

    public interface IBuilder
    {
        void StartBuilding(IBuildable buildable);
        // bool IsBuilding { get; }
    }
    public interface ISensor
    {
        // float DetectionRange { get; }
        void DetectUnitsInRange();
    }
    public interface IAttackingByBranchOf : IAttacking
    {
        // public Dictionary<Type, int?>? prioritiesToUnits { get; }
    }
    public interface IExperiencable : IUpdatable
    {
        // public float ExperienceComponent { get; }
        // public float? upgradeTime { get; }
        // public Dictionary<string, float> BuffsSomeoneField { get; }
    }
    public interface IMovingOnFoot : IMovable
    {
        new void MoveTo(Vector3 targetPosition);
    }
    public interface IDriving : IMovable
    {
        new void MoveTo(Vector3 targetPosition);
    }
    public interface IFlying : IMovable
    {
        new void MoveTo(Vector3 targetPosition);
    }
    public interface IUpdatable
    {
        void MethodUpdate(float value);
    }
    public interface IProjectileMoving : IMovable
    {
        new void MoveTo(Vector3 targetPosition);
    }
    public interface IMissileMoving : IProjectileMoving
    {
        new void MoveTo(Vector3 targetPosition);
    }
    public interface ISelecting
    {
        
    }
}
