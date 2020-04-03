using System;
using UnityEngine;


public interface IInputHandler
{
    event Action<Vector3> Move;
    event Action Throw;
}

