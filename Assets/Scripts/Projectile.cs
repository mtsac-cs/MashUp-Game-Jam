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
        travelDir =  Camera.main.ScreenToWorldPoint(new Vector3(direction.x, direction.y));
        
        /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        StartCoroutine(Move(direction));*/
    }

    
    private void FixedUpdate()
    {
        if (!travelDir.HasValue)
            return;

        if (distanceTravelled > maxProjectileDistance)
        {
            Debug.Log("Projectile destroy");
            GameObject.Destroy(gameObject);
        }
        
        var direction = travelDir.Value;

        rb.AddForce(direction);
        //transform.position = Vector2.MoveTowards(transform.position, direction, projectileSpeed * Time.deltaTime);
        distanceTravelled += projectileSpeed;
    }

    /*private IEnumerator Move(Vector3 direction)
    {
        float distanceTravelled = 0f;
        float amountToTravel = 0.01f;
        direction = Camera.main.ScreenToWorldPoint(new Vector3(direction.x, direction.y, 0.0f));

        while (distanceTravelled < maxProjectileDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, direction, amountToTravel);
            
            yield return new WaitForEndOfFrame();
            distanceTravelled += amountToTravel;
            
        }
    }*/

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