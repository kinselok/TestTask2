using UnityEngine;


public class Mover : MonoBehaviour
{
    #region Editor    
    [SerializeField]
    protected Vector3 maxPosition;
    [SerializeField]
    protected Vector3 minPosition;
    #endregion

    protected IInputHandler input;


    protected virtual void Awake()
    {
        input = GetComponent<IInputHandler>();
        input.Move += Move;
    }


    protected virtual void Move(Vector3 position)
    {
        transform.position = WorldToGameFieldPoint(position);
    }


    protected Vector3 WorldToGameFieldPoint(Vector3 point)
    {
        Vector3 gameFieldPosition = point;
        //Check X coordinate
        if(point.x < minPosition.x)
            gameFieldPosition.x = minPosition.x;
        else
        if(point.x > maxPosition.x)
            gameFieldPosition.x = maxPosition.x;

        //Check Y coordinate
        if(point.y < minPosition.y)
            gameFieldPosition.y = minPosition.y;
        else
        if(point.y > maxPosition.y)
            gameFieldPosition.y = maxPosition.y;

        //Check Z coordinate
        if(point.z < minPosition.z)
            gameFieldPosition.z = minPosition.z;
        else
        if(point.z > maxPosition.z)
            gameFieldPosition.z = maxPosition.z;

        return gameFieldPosition;
    }
}

