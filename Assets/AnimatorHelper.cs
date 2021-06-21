using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHelper : MonoBehaviour
{
    public RangedWeapon rangedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        rangedWeapon = transform.parent.GetComponent<RangedWeapon>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void JumpAttack()
    {
        transform.parent.GetComponent<RangedWeapon>().EnemyWeapon();

    }
    public void DashAttack()
    {
        transform.parent.GetComponent<RangedWeapon>().EnemyWeapon();
    }
}
