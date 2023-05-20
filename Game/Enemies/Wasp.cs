using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Enemies
{
    public class Wasp : Enemy
    {
        public Wasp() :
            base(
                    150,
                    2,
                    11,
                    new Animation(GameController.AnimationBank.AnimationPerDynamicsId[(int)EnemyIdName.Wasp])
                )
        {
            ObjectID = (int)EnemyIdName.Wasp;
        }


    }
}
