using System;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IDamageHandler
{
    #region Editor
    [SerializeField]
    private int health = 0;
    #endregion
    private int currentHealth;
    public event Action OnDestroy;


    private void Awake()
    {
        currentHealth = health;
    }


    public void Init()
    {
        currentHealth = health;
        gameObject.SetActive(true);
    }


    public void ApplyDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            OnDestroy();
        }
    }
}
