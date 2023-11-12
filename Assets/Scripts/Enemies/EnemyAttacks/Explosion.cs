using JK.Roguelike;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float fillSteps = 10;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform fill;

    private float explosionRange;
    private float damage;

    public void Initialize(Vector2 position, float explosionRange, float damage)
    {
        transform.position = position;
        transform.localScale = new Vector2(explosionRange, explosionRange);
        this.damage = damage;
        this.explosionRange = explosionRange;
        StartCoroutine(FillRange());
    }

    private IEnumerator FillRange()
    {
        SpriteRenderer renderer = fill.GetComponent<SpriteRenderer>();

        Color color = renderer.color;
        Color finishColor = new(1f, 0f, 0f, .5f);
        float scale = 1 / fillSteps;
        for (int i = 1; i <= fillSteps; i++)
        {
            fill.localScale = new Vector3(i * scale, i * scale, 0);
            renderer.color = Vector4.Lerp(color, finishColor, i * scale);
            yield return new WaitForSeconds(scale * speed);
        }

        Collider2D[] objectsHit = Physics2D.OverlapCircleAll(transform.position, explosionRange);

        foreach (Collider2D hit in objectsHit)
        {
            hit.TryGetComponent<Health>(out Health hitEntity);
            if (hitEntity != null)
                hitEntity.DoDamage(damage);
        }

        Destroy(gameObject);
    }
}
