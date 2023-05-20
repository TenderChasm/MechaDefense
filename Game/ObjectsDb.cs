using MechaDefense.Game.Buildings;
using MechaDefense.Game.Enemies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public class ObjectsDb
    {
        public delegate Enemy CreateInstanceEnemy();
        public delegate Building CreateInstanceBuilding();
        public Dictionary<int, CreateInstanceBuilding> Statics { get; set; }
        public Dictionary<int, CreateInstanceEnemy> Enemies { get; set; }

        public ObjectsDb()
        {
            Statics = new Dictionary<int, CreateInstanceBuilding>();
            Enemies = new Dictionary<int, CreateInstanceEnemy>();
            Fill();
        }

        public void Fill()
        {
            Enemies.Add((int)EnemyIdName.Burglar, () => new Burglar());
            Enemies.Add((int)EnemyIdName.Viper, () => new Viper());
            Enemies.Add((int)EnemyIdName.Wasp, () => new Wasp());

            Statics.Add((int)BuildingIdName.GreenForest, () => new GreenForest());
            Statics.Add((int)BuildingIdName.Stone, () => new Stone());
            Statics.Add((int)BuildingIdName.HangarGreen, () => new HangarGreen());
            Statics.Add((int)BuildingIdName.HangarOrange, () => new HangarOrange());
            Statics.Add((int)BuildingIdName.Factory, () => new Factory());
            Statics.Add((int)BuildingIdName.PowerPlant, () => new PowerPlant());
            Statics.Add((int)BuildingIdName.Radar, () => new Radar());
        }
    }
}
