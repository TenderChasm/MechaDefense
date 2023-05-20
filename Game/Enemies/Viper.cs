using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Enemies
{
    public class Viper : Enemy
    {
        public Viper() :
            base(
                    50,
                    2,
                    6,
                    new Animation(GameController.AnimationBank.AnimationPerDynamicsId[(int)EnemyIdName.Viper])
                )
        {
            ObjectID = (int)EnemyIdName.Viper;
        }
    }
}
