using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike
{
    public class StraightMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D enemyRigidbody;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private float movementSpeed = 10;
        [SerializeField] private float attackRange = 1;

        private GameObject target;
        private bool isAttacking;

        private Action attack;

        private void Start()
        {
            GetTarget();

            attack += enemyAttack.InitiateAttack;
            attack += StartAttacking;
            enemyAttack.StopAttack += StopAttacking;
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
            if(target != null && !isAttacking)
            {
                Vector2 lookDirection = (target.transform.position - transform.position).normalized;
                float actualRotation = (float)(Mathf.Atan2(lookDirection.x, lookDirection.y) / Mathf.PI) * 180 * -1;

                Quaternion walkRotation = Quaternion.Euler(new Vector3(0, 0, actualRotation));
                transform.rotation = walkRotation;

                if (Vector2.Distance(target.transform.position, transform.position) > attackRange)
                    enemyRigidbody.velocity = movementSpeed * Time.deltaTime * transform.up;
                else
                    Attack();
            }
        }

        private void Attack()
        {
            enemyRigidbody.velocity = Vector2.zero;
            attack.Invoke();

        }

        private void StartAttacking() => isAttacking = true;
        private void StopAttacking() => isAttacking = false;
    }
}