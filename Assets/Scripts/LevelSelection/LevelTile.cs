using System;
using System.Linq;
using UnityEngine;

namespace JK.Roguelike
{
    public class LevelTile : MonoBehaviour
    {
        private bool isOpenRoom;
        private TileType type;
        private SpriteRenderer spriteRenderer;

        public Vector2 TilePosition { get; private set; }

        public void Initialize(int tileIndentifier)
        {
            TilePosition = transform.position;
            spriteRenderer = GetComponent<SpriteRenderer>();

            if (tileIndentifier == 2)
                type = TileType.EndBoss;
            else if (tileIndentifier == 1)
                OpenTile();
            else
                type = (TileType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(TileType)).Cast<int>().Max() - 1);

            SetSprite();
        }

        private void OnMouseDown()
        {
            if(isOpenRoom)
                LoadLevel();
        }

        public void LoadLevel()
        {
            isOpenRoom = false;
            spriteRenderer.color = Color.gray;

            GridGenerator.Instance.OpenAdjacentTiles(this);
            GameManager.Instance.ToggleLevelSelectUI();
            GameManager.Instance.LoadNewGame(2);
        }

        private void SetSprite()
        {
            // TODO: change icons not color
            switch (type)
            {
                case TileType.Combat:
                    break;
                case TileType.Treasure:
                    break;
                case TileType.MiniBoss:
                    break;
                case TileType.EndBoss:
                    spriteRenderer.color = Color.red;
                    break;
            }
        }

        public void OpenTile()
        {
            isOpenRoom = true;
            spriteRenderer.color = Color.green;
        }
    }
}