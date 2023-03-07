using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform CamTransform;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Damage();
        }
    }

    private void Damage()
    {
        RaycastHit hit;

        if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
        {
            Enemy hitEnemy = hit.collider.GetComponent<Enemy>();

            if (hitEnemy != null)
            {
                hitEnemy.TakeDamage(gameObject.GetComponent<Player>().attack);
            }
        }
    }


}
