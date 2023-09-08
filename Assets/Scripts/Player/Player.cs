using UnityEngine;

namespace JK.Roguelike
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private float movementSpeed = 2500;


        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Vector2 moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveDirection.Normalize();

            playerRigidbody.velocity = movementSpeed * Time.deltaTime * moveDirection;
        }
    }
}