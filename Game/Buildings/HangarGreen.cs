using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Buildings
{

    public class HangarGreen : Building
    {
        public HangarGreen() :
            base(
                    300
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\hangarGreen.png"];
            ObjectID = (int)BuildingIdName.HangarGreen;
        }
    }
}
