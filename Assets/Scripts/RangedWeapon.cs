using System.Collections;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Health health;
    public GameObject projectilePrefab;
    public Projectile ProjectileModel { get { return projectilePrefab.GetComponent<Projectile>(); } }
    public GameObject particleEffect;
    public GameObject particleEffect1;
    public ActiveActorData actorData;
    public float damage = 2f;
    public float fireRate;
    bool isFiring;
    bool isEnemy = false;
    private GameObject bulletContainer;
    void Start()
    {
        health = gameObject.GetOrAddComponent<Health>();
        bulletContainer = Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        bulletContainer.transform.parent = null;
        bulletContainer.transform.name = "BulletContainer";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isFiring && !isEnemy)
        {
            StartCoroutine(FireWeapon());
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Vector2 travelDir = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
    //     travelDir = travelDir.normalized;
    //     Gizmos.color = Color.cyan;
    //     Gizmos.DrawLine(Vector2.zero,travelDir);
    // }
    IEnumerator FireWeapon()
    {
        var particle = GameObject.Instantiate(particleEffect, transform);
        var particle1 = GameObject.Instantiate(particleEffect1, transform);
        Vector2 travelDir = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
        travelDir = travelDir.normalized;
        float angle = Mathf.Atan2(Input.mousePosition.y, Input.mousePosition.x) * Mathf.Rad2Deg - 90;
        angle = Vector2.Angle(Vector2.right, travelDir);

        if (angle > 0 && travelDir.y > 0)
        {
            particle.transform.rotation = Quaternion.Euler(0, 0, angle);
            particle1.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (travelDir.y < 0)
        {
            particle.transform.rotation = Quaternion.Euler(0, 0, angle * -1);
            particle1.transform.rotation = Quaternion.Euler(0, 0, angle * -1);

        }
        health.DealDamage(damage);
        AudioSource.PlayClipAtPoint(actorData.attackSound, transform.position);
        isFiring = true;
        var projectileGO = GameObject.Instantiate(projectilePrefab, transform, bulletContainer);
        projectileGO.transform.parent = bulletContainer.transform;
        projectileGO.transform.position = transform.position;

        var projectile = projectileGO.GetComponent<Projectile>();

        projectile.Init(Input.mousePosition);

        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }

    public void EnemyWeapon()
    {
        var particle = GameObject.Instantiate(particleEffect, transform);
        var particle1 = GameObject.Instantiate(particleEffect1, transform);
        Vector2 travelDir = Player.instance.transform.position - Enemy.instance.transform.position;
        travelDir = travelDir.normalized;
        float angle = Vector2.Angle(Vector2.right, travelDir);

        if (angle > 0 && travelDir.y > 0)
        {
            particle.transform.rotation = Quaternion.Euler(0, 0, angle);
            particle1.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (travelDir.y < 0)
        {
            particle.transform.rotation = Quaternion.Euler(0, 0, angle * -1);
            particle1.transform.rotation = Quaternion.Euler(0, 0, angle * -1);

        }
        health.DealDamage(damage);
        AudioSource.PlayClipAtPoint(actorData.attackSound, transform.position);
        isFiring = true;
        var projectileGO = GameObject.Instantiate(projectilePrefab, transform, bulletContainer);
        projectileGO.transform.parent = bulletContainer.transform;
        projectileGO.transform.position = transform.position;

        var projectile = projectileGO.GetComponent<Projectile>();

        projectile.Init(travelDir);
        isFiring = false;
    }
    public void EnemySplash(int numBullets)
    {
        float angle = 360f / numBullets;
        for (int i = 0; i < numBullets; i++)
        {
            Quaternion angleQ = Quaternion.Euler(0, 0, angle * i);
            Vector3 vecForAng = angleQ * Vector2.right;
            vecForAng = vecForAng.normalized;
            var projectileGO = GameObject.Instantiate(projectilePrefab, transform, bulletContainer);
            projectileGO.transform.parent = bulletContainer.transform;
            projectileGO.transform.position = transform.position;

            var projectile = projectileGO.GetComponent<Projectile>();

            projectile.Init(vecForAng);
        }
    }
}
