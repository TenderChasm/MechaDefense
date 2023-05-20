using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Buildings
{
    public class Stone : Building
    {
        public Stone() :
            base(
                    100
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\stone.png"];
            ObjectID = (int)BuildingIdName.Stone;
        }
    }
}
