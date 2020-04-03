using System;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    #region Editor
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private int basePower = 10;
    #endregion

    private IInputHandler input;
    private bool isBallReady = true;

    // Start is called before the first frame update
    void Awake()
    {
        input = GetComponent<IInputHandler>();
        input.Throw += Throw;
        ball.OnDestroy += () => isBallReady = true;
    }


    private void Throw()
    {
        if(isBallReady)
        {
            ball.transform.LookAt(transform);
            var powerMultiplier = (ball.transform.position - transform.position).magnitude;
            ball.Rigidbody.AddForce(ball.transform.forward * basePower * powerMultiplier , ForceMode.VelocityChange);
            isBallReady = false;
        }
    }

}
