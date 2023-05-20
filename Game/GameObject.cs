using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    public enum DeathState
    {
        Alive,
        Dying,
        Dead
    }
    public abstract class GameObject
    {
        public int ObjectID { get; protected set; }
        public Point Coords { get; set; }

        private int durability;
        public int Durability
        {
            get
            {
                return durability;
            }
            set
            {
                if (State == DeathState.Alive)
                {
                    durability = value;
                    if(value <= 0)
                        State = DeathState.Dying;
                }
            }
        }
        public Animation DeathAnimation { get; set; } = new Animation(GameController.AnimationBank.DefaultDeath);
        public DeathState State { get; set; } = DeathState.Alive;

        public GameObject(Point coords)
        {
            Coords = coords;
        }

        public GameObject()
        {
        }
    }
}
