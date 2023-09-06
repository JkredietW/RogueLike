using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    public class LevelTile : MonoBehaviour
    {
        private bool isOpenRoom = true;

    }

    public enum TileTypes
    {
        Default,
        Treasure,
        Boss,
        EndBoss,
    }
}