using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game.Buildings
{
    public class HangarOrange : Building
    {
        public HangarOrange() :
            base(
                    450
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\hangarOrange.png"];
            ObjectID = (int)BuildingIdName.HangarOrange;
        }
    }
}
