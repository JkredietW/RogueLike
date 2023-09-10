using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    public class StraightMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D enemyRigidbody;
        [SerializeField] private float movementSpeed = 10;
        private GameObject target;

        private void Start()
        {
            GetTarget();
        }

        private void GetTarget()
        {
            target = GameManager.Instance.SpawnedPlayer;
        }

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            if(target != null)
            {
                Vector2 lookDirection = (target.transform.position - transform.position).normalized;
                float actualRotation = (float)(Mathf.Atan2(lookDirection.x, lookDirection.y) / Mathf.PI) * 180 * -1;

                Quaternion walkRotation = Quaternion.Euler(new Vector3(0, 0, actualRotation));
                transform.rotation = walkRotation;

                enemyRigidbody.velocity = movementSpeed * Time.deltaTime * transform.up;
            }
        }
    }
}