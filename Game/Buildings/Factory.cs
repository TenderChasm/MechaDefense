using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Buildings
{
    public class Factory : Building
    {
        public Factory() :
            base(
                    600
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\factory.png"];
            ObjectID = (int)BuildingIdName.Factory;
        }
    }
}
