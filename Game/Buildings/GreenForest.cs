using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Buildings
{
    public class GreenForest : Building
    {
        public GreenForest() :
            base(
                    60
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\greenForest.png"];
            ObjectID = (int)BuildingIdName.GreenForest;
        }
    }
}
