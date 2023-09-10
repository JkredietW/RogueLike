using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    public class GridGenerator : MonoBehaviour
    {
        public static GridGenerator Instance { get; private set; }

        [SerializeField] private int totalTiles = 25;
        [SerializeField] private LevelTile TilePrefab;

        private Vector2[] tileDirections =
        {
        Vector2.down, Vector2.up, Vector2.left, Vector2.right,
    };

        private void Awake() => Instance = this;

        public void StartGeneration()
        {
            List<Vector2> open = new List<Vector2>();
            List<Vector2> closed = new List<Vector2>();

            Vector2 currentLocation = new Vector2();
            for (int i = 0; i < totalTiles; i++)
            {
                closed.Add(currentLocation);
                LevelTile newtile = Instantiate(TilePrefab, currentLocation, Quaternion.identity, transform);

                for (int j = 0; j < tileDirections.Length; j++)
                    if (!closed.Contains(tileDirections[j] + currentLocation))
                        open.Add(tileDirections[j] + currentLocation);

                open.Remove(currentLocation);
                currentLocation = open[Random.Range(0, open.Count - 1)];

                newtile.Initialize(i == totalTiles);
            }
        }
    }
}