using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 initialPos;
    public event Action OnDestroy;
    public int Damage { get; set; }
    public Rigidbody Rigidbody { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        Damage = 10;
        Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<IDamageHandler>(out var damageHandler))
        {
            damageHandler.ApplyDamage(Damage);           
            Rigidbody.velocity = Vector3.zero;
            transform.position = initialPos;
            OnDestroy();
        }
    }
}
