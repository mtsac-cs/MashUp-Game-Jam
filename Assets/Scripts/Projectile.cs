using System;
using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public enum UseableTags
{
    Player, Enemy
}
[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteract => new UnityEvent();
    public float damageAmount = 1f;
    public UseableTags targetTag;
    public UseableTags ignoreTag;

    [NonSerialized]
    public Rigidbody2D rb;

    Vector2? travelDir = null;
    float projectileSpeed = 20f;
    float distanceTravelled = 0f;
    float maxProjectileDistance = 500;
    public float bulletDamage = 5;

    private void Awake()
    {
        if (ignoreTag.ToString() != "Enemy")
        {
            Destroy(this.gameObject, 10f);
        }
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 direction)
    {
        //travelDir = Camera.main.ScreenToWorldPoint(new Vector3(direction.x, direction.y)) - Camera.main.WorldToScreenPoint(transform.position);
        if (targetTag.ToString() == "Enemy")
        {
            travelDir = (direction - Camera.main.WorldToScreenPoint(transform.position));
            travelDir = travelDir.Value.normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            angle = Vector2.Angle(Vector2.right, travelDir.Value);
            //float angle = Mathf.Atan2(travelDir.Value.y, travelDir.Value.x) * Mathf.Rad2Deg - 90;
            // if (travelDir.Value.x > 0 && travelDir.Value.y > 0) //1st quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, angle);
            // }
            // else if (travelDir.Value.x < 0 && travelDir.Value.y > 0) //2nd quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, angle+90);
            // }
            // else if (travelDir.Value.x < 0 && travelDir.Value.y < 0) //3rd quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, Mathf.Abs(angle)+180);
            // }
            // else if (travelDir.Value.x > 0 && travelDir.Value.y < -90) //4th quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, Mathf.Abs(angle)+270);
            // }
            if (angle > 0 && travelDir.Value.y > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
            else if (travelDir.Value.y < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, angle * -1);
            }

            //transform.Rotate(transform.rotation.x, transform.rotation.y, angle);
            //rb.MoveRotation(angle);
            direction = travelDir.Value;
            Vector2 test = new Vector2(direction.x, direction.y);
            //rb.AddForce(test * projectileSpeed * .2f, ForceMode2D.Impulse);
            rb.AddForce(travelDir.Value * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            float angle = Vector2.Angle(Vector2.right, travelDir.Value);
            //float angle = Mathf.Atan2(travelDir.Value.y, travelDir.Value.x) * Mathf.Rad2Deg - 90;
            // if (travelDir.Value.x > 0 && travelDir.Value.y > 0) //1st quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, angle);
            // }
            // else if (travelDir.Value.x < 0 && travelDir.Value.y > 0) //2nd quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, angle+90);
            // }
            // else if (travelDir.Value.x < 0 && travelDir.Value.y < 0) //3rd quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, Mathf.Abs(angle)+180);
            // }
            // else if (travelDir.Value.x > 0 && travelDir.Value.y < -90) //4th quadrant
            // {
            //     transform.localRotation = Quaternion.Euler(0, 0, Mathf.Abs(angle)+270);
            // }
            if (angle > 0 && travelDir.Value.y > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
            else if (travelDir.Value.y < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, angle * -1);
            }
            rb.AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
        }
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == targetTag.ToString())
        {
            other.GetComponent<Health>().DealDamage(5);
            Destroy(this.gameObject);

        }
        else if (other.tag == ignoreTag.ToString())
        {
        }
        else
        {
            Destroy(this.gameObject);

        }
    }
}