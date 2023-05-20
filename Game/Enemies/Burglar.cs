using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Enemies
{
    public class Burglar : Enemy
    {
        public Burglar() : 
            base(
                    100,
                    1,
                    3,
                    new Animation(GameController.AnimationBank.AnimationPerDynamicsId[(int)EnemyIdName.Burglar])
                )
        {
            ObjectID = (int)EnemyIdName.Burglar;
        }
    }
}
