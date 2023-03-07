using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Stats
{
    [SerializeField] private Slider healthBar;

    private bool isTakingDamage = false;
    
    public override int GetHealth()
    {
        return this.health;
    }

    public override void TakeDamage(int value)
    {
        this.health -= value;
        healthBar.value = this.health;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Enemy" && !isTakingDamage)
        {
            TakeDamage(hit.transform.GetComponent<Enemy>().attack);
            isTakingDamage = true;
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(2);
        isTakingDamage = false;
    }
}
