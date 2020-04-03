using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IInputHandler, IDamageHandler
{
    #region Editor
    [SerializeField]
    private int speed;
    #endregion
    public event Action<Vector3> Move;
    public event Action Throw;
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private IEnumerator MoveToBallCoroutine;


    private IEnumerator MoveToBall(Transform ball)
    {
        while(true)
        {
            var nextPos = Vector3.Lerp(transform.position, ball.position, Time.deltaTime * speed);
            Move(nextPos);
            yield return new WaitForFixedUpdate();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        MoveToBallCoroutine = MoveToBall(other.transform);
        StartCoroutine(MoveToBallCoroutine);
    }


    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(MoveToBallCoroutine);
    }

    //Catch Ball
    public void ApplyDamage(int amount)
    {
        StopCoroutine(MoveToBallCoroutine);
    }
}
