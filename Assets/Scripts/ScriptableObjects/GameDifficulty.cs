using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    [CreateAssetMenu(fileName = "Difficulty", menuName = "Game/Difficulty")]
    public class GameDifficulty : ScriptableObject
    {
        public int MaxHealth;
        public int MaxSpawnEnemies;
    }
}