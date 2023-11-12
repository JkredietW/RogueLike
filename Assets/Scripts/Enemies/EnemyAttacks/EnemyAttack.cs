using JK.Roguelike;
using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private StraightMovement movementClass;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float attackDuration = 1;
    [SerializeField] private float explosionRange = 2;
    [SerializeField] private float explosionDamage = 1;


    [Header("attacks")]
    [SerializeField] private Explosion explosionPrefab;

    public Action StopAttack;
    public Action AttackAtion;

    private void Start()
    {
        AttackAtion += SelfDestruckt;
    }

    public void InitiateAttack()
    {
        AttackAtion?.Invoke();
        Invoke(nameof(DoneAttacking), attackDuration);
    }

    public void DoneAttacking()
    {
        StopAttack?.Invoke();
    }

    private void SelfDestruckt()
    {
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        Color startColor = spriteRenderer.color;
        Color finishColor = new(1f, 0f, 0f, .5f);
        Instantiate(explosionPrefab).Initialize(transform.position, explosionRange, explosionDamage);

        for (int i = 1; i <= 10; i++)
        {
            spriteRenderer.color = Vector4.Lerp(startColor, Color.red, i * .1f);
            yield return new WaitForSeconds(attackDuration / 10);
        }
        GetComponent<Health>().OneHit();
    }
}
