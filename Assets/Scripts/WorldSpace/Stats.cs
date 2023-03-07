using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    public int health;
    public int attack;

    public abstract int GetHealth();

    public abstract void TakeDamage(int value);
}
