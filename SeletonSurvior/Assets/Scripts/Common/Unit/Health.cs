using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
    public IntVarValue health;
    public UnityEvent OnDestroyed;
    bool destroyedFromHealth = false;
    public void RecieveDamage(int dmg)
    {
        health.Value -= dmg;
        if (health.Value <= 0)
        {
            destroyedFromHealth = true;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (destroyedFromHealth)
        {
            OnDestroyed.Invoke();
        }
    }
}
