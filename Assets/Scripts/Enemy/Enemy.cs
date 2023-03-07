using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : Stats
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Canvas canvas;
    private EnemyController enemyControl;
    private GameObject cameraObject;    

    private void Start()
    {
        enemyControl = GameObject.FindGameObjectWithTag("Master").GetComponent<EnemyController>();
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        canvas.worldCamera = cameraObject.GetComponent<Camera>();
    }

    public override int GetHealth()
    {
        return this.health;
    }

    public override void TakeDamage(int value)
    {
        this.health -= value;
        healthBar.value = this.health;

        if (this.health <= 0)
        {
            enemyControl.AddCount();
            Destroy(gameObject);
        }
    }
}
