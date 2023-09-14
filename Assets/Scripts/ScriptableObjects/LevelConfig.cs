using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    [CreateAssetMenu(fileName = "Config", menuName = "Game/Level config")]
    public class LevelConfig : ScriptableObject
    {
        public TileType Mode;
        public float RareSpawnChance;
        public List<Wave> waves;
    }

    public enum TileType
    {
        Combat,
        Treasure,
        MiniBoss,
        EndBoss,
    }
}
