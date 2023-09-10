using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    [CreateAssetMenu(fileName = "Difficulty", menuName = "Game/Difficulty")]
    public class GameDifficulties : MonoBehaviour
    {
        public TileType Difficulty;
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
