using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;


namespace Units
{
#nullable enable
    public abstract class Unit : MonoBehaviour, ISelectable
    {
        public Player Player = Camera.main.gameObject.GetComponent<Player>();
        public string state; 
        public float rangeOfView; 
        public Queue<Task> Tasks = new Queue<Task>(); 
        public HealthComponent Health; 
        public ExperienceComponent? Experience = null; 
        public ShieldFieldComponent? ShieldField = null; 
        public TurretComponent? Turret = null; 
        public MaterialComponent? Material = null; 
        public EnergyComponent? Energy = null;
        public Outline outline; 
        private bool isSelected; 

        public Unit(Player player, string state, float rangeOfView, Queue<Task> Tasks, ExperienceComponent? Experience, ShieldFieldComponent shieldField, TurretComponent turret, MaterialComponent material, EnergyComponent energy)
        {
            this.Player = player;
            this.state = state;
            this.rangeOfView = rangeOfView;
            this.Tasks = Tasks;
            this.Experience = Experience;
            this.ShieldField = shieldField;
            this.Turret = turret;
            this.Material = material;
            this.Energy = energy;
        }
        private void Start()
        {
            outline = gameObject.AddComponent<Outline>();
            outline.enabled = false;
        }

        public void Deselect()
        {

        }

        public void Select()
        {

        }

        protected virtual void Assist()
        {
            // TODO: Implement assist logic
        }
    }
}