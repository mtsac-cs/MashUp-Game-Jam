using System.Collections;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Projectile ProjectileModel { get { return projectilePrefab.GetComponent<Projectile>(); } }

    public ActiveActorData actorData;
    public float fireRate;
    bool isFiring;

    private GameObject bulletContainer;
    void Start()
    {
        bulletContainer = Instantiate(new GameObject(),Vector3.zero,Quaternion.identity);    
        bulletContainer.transform.parent = null;
        bulletContainer.transform.name = "BulletContainer";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isFiring)
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
        AudioSource.PlayClipAtPoint(actorData.attackSound,transform.position);
        isFiring = true;
        var projectileGO = GameObject.Instantiate(projectilePrefab, transform,bulletContainer);
        projectileGO.transform.parent = bulletContainer.transform;
        projectileGO.transform.position = transform.position;

        var projectile = projectileGO.GetComponent<Projectile>();
        
        projectile.Init(Input.mousePosition);

        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
