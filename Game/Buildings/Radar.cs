using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Buildings
{
    public class Radar : Building
    {
        public Radar() :
            base(
                    200
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\radar.png"];
            ObjectID = (int)BuildingIdName.Radar;
        }
    }
}
