using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense
{
    public class PowerPlant : Building
    {
        public PowerPlant() : 
            base(
                    900
                )
        {
            Sprite = GameController.AssetLoader.Assets["statics\\powerPlant.png"];
            ObjectID = (int)BuildingIdName.PowerPlant;
        }

    }
}
