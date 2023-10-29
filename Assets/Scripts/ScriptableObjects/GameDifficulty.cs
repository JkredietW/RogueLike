using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    [CreateAssetMenu(fileName = "Difficulty", menuName = "Game/Difficulty")]
    public class GameDifficulty : ScriptableObject
    {
        [Header("Multipliers")]
        public float MaxSpawnEnemies = 1;
        public float EnemyHealth = 1;
        public float EnemyDamage = 1;
        public float EnemySpeed = 1;
        public float EliteChance = 1;
        public float EliteStats = 1;
        public float ItemDropChance = 1;
    }
}