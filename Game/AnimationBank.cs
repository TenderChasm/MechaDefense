using MechaDefense.Game.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MechaDefense.Game
{
    public class AnimationBank
    {
        public Animation DefaultDeath { get; set; }
        public Animation BombExplosion { get; set; }
        public Dictionary <int, Animation> AnimationPerDynamicsId { get; set; }

        public AnimationBank()
        {
            AnimationPerDynamicsId = new Dictionary<int, Animation>();

            DefaultDeath = new Animation();
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\0.png"], 3));
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\1.png"], 6));
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\2.png"], 9));
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\3.png"], 12));
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\4.png"], 15));
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\5.png"], 18));
            DefaultDeath.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\death\\6.png"], 21));

            AnimationPerDynamicsId[(int)EnemyIdName.Burglar] = new Animation();
            List<Animation.Frame> burglarAnimData = AnimationPerDynamicsId[(int)EnemyIdName.Burglar].Data;
            burglarAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\burglar\\0.png"], 3));
            burglarAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\burglar\\1.png"], 6));
            burglarAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\burglar\\2.png"], 9));
            burglarAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\burglar\\3.png"], 12));

            AnimationPerDynamicsId[(int)EnemyIdName.Viper] = new Animation();
            List<Animation.Frame> viperAnimData = AnimationPerDynamicsId[(int)EnemyIdName.Viper].Data;
            viperAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\viper\\0.png"], 4));
            viperAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\viper\\1.png"], 8));
            viperAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\viper\\2.png"], 12));
            viperAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\viper\\3.png"], 16));

            AnimationPerDynamicsId[(int)EnemyIdName.Wasp] = new Animation();
            List<Animation.Frame> waspAnimData = AnimationPerDynamicsId[(int)EnemyIdName.Wasp].Data;
            waspAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\wasp\\0.png"], 7));
            waspAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\wasp\\1.png"], 14));
            waspAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\wasp\\2.png"], 21));
            waspAnimData.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\wasp\\3.png"], 28));

            BombExplosion = new Animation();
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\0.png"], 3));
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\1.png"], 6));
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\2.png"], 9));
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\3.png"], 12));
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\4.png"], 15));
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\5.png"], 18));
            BombExplosion.Data.Add(new Animation.Frame(GameController.AssetLoader.Assets["enemies\\bomb\\6.png"], 21));

            AnimationPerDynamicsId[(int)Settings.ShipColor.Yellow] = new Animation();
            List<Animation.Frame> yellowShipData = AnimationPerDynamicsId[(int)Settings.ShipColor.Yellow].Data;
            yellowShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\yellow\\0.png"], 4));
            yellowShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\yellow\\1.png"], 8));
            yellowShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\yellow\\2.png"], 12));
            yellowShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\yellow\\3.png"], 16));

            AnimationPerDynamicsId[(int)Settings.ShipColor.Red] = new Animation();
            List<Animation.Frame> redShipData = AnimationPerDynamicsId[(int)Settings.ShipColor.Red].Data;
            redShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\red\\0.png"], 4));
            redShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\red\\1.png"], 8));
            redShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\red\\2.png"], 12));
            redShipData.Add(new Animation.Frame(GameController.AssetLoader.Assets["player\\red\\3.png"], 16));

        }
    }
}
