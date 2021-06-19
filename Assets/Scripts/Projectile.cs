using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteract => new UnityEvent();
    public float damageAmount = 1f;

    void Start()
    {
        
    }

    public void Init(Vector3 direction)
    {
        Debug.Log(direction.ToString());
        //StartCoroutine(Move(direction));
    }

    private IEnumerator Move(Vector3 direction)
    {
        yield return null;
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