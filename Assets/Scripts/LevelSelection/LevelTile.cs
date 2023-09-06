using System;
using System.Linq;
using UnityEngine;

namespace JK.Roguelike
{
    public class LevelTile : MonoBehaviour
    {
        private bool isOpenRoom = true;
        private TileType type;
        public void Initialize(bool isLast)
        {
            if (isLast)
                type = TileType.EndBoss;
            else
                type = (TileType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(TileType)).Cast<float>().Max() - 1);
        }
    }

    public enum TileType
    {
        Combat,
        Treasure,
        MiniBoss,
        EndBoss,
    }
}