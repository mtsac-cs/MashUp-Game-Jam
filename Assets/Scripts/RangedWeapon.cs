using System.Collections;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Projectile ProjectileModel { get { return projectilePrefab.GetComponent<Projectile>(); } }


    public float fireRate;
    bool isFiring;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isFiring)
        {
            StartCoroutine(FireWeapon());
        }
    }

    IEnumerator FireWeapon()
    {
        isFiring = true;
        var projectileGO = GameObject.Instantiate(projectilePrefab, transform);
        projectileGO.transform.position = transform.position;

        var projectile = projectileGO.GetComponent<Projectile>();
        
        projectile.Init(Input.mousePosition);

        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
