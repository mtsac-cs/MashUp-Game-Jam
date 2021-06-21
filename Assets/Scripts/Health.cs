using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathParticle;
    public float health = 100;
    public float curHealth = 100;

    public Text deathText;
    public GameObject graphic;
    SpriteRenderer spriteRenderer;
    public Image healthBar;
    void Start()
    {
        curHealth = health;
        spriteRenderer = graphic.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(float amount)
    {
        curHealth -= amount;
        curHealth = Mathf.Clamp(curHealth, 0, 100000);
        healthBar.fillAmount = curHealth/health;
        if (curHealth <= 0)
        {
            Death();
        }

        this.GetComponent<PlayerSound>().PlayOnHitSound();
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", .1f);
    }
    public void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }

    public void Death()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        this.GetComponent<PlayerSound>().PlayDeathSound();
        Destroy(this.gameObject);
    }
    void OnDestroy()
    {
        deathText.gameObject.SetActive(true);
    }
}
