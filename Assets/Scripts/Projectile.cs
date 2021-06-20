using System;
using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteract => new UnityEvent();
    public float damageAmount = 1f;

    [NonSerialized]
    public Rigidbody2D rb;

    Vector2? travelDir = null;
    float projectileSpeed = 20f;
    float distanceTravelled = 0f;
    float maxProjectileDistance = 500;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 direction)
    {
        //travelDir = Camera.main.ScreenToWorldPoint(new Vector3(direction.x, direction.y)) - Camera.main.WorldToScreenPoint(transform.position);
        travelDir = (direction - Camera.main.WorldToScreenPoint(transform.position))*1000;
        travelDir = travelDir.Value.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //float angle = Mathf.Atan2(travelDir.Value.y, travelDir.Value.x) * Mathf.Rad2Deg - 90;

        //transform.Rotate(transform.rotation.x, transform.rotation.y, angle);
        rb.MoveRotation(angle);

        direction = travelDir.Value;
        Vector2 test = new Vector2(direction.x, direction.y);
        rb.AddForce(test * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        if (!travelDir.HasValue)
            return;

        return;
        /*if (distanceTravelled > maxProjectileDistance)
        {
            Debug.Log("Projectile destroy");
            GameObject.Destroy(gameObject);
        }*/

        var direction = travelDir.Value;

        Vector2 test = new Vector2(direction.x, -direction.y);
        rb.AddForce(-direction * projectileSpeed * Time.deltaTime, ForceMode2D.Impulse);


        //rb.SetRotation(angle);

        //var rotate = Vector3.RotateTowards(transform.position, direction, 360, 10);

        //transform.Rotate(direction);

        //rb.AddForce(-direction);
        //transform.position = Vector2.MoveTowards(transform.position, direction, projectileSpeed * Time.deltaTime);
        distanceTravelled += projectileSpeed;
    }

    public bool CanInteract() => true;

    public void Interact(GameObject owner, GameObject interactable)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile");
        if (collision.gameObject.HasComponent<IDamagable>(out var damagable))
        {
            damagable.Damage(damageAmount);
        }

        Destroy(this.gameObject);
    }
}