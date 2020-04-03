using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

class MouseInput : MonoBehaviour, IInputHandler
{
    #region Editor
    [SerializeField]
    private GameObject inputField;
    #endregion

    private bool isMoving = false;

    public event Action<Vector3> Move;
    public event Action Throw;

    private void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject(-1))
        {
            if(Input.GetMouseButtonDown(0))
            {
                isMoving = true;
            }
            if(Input.GetMouseButtonUp(0))
            {
                Throw();
                isMoving = false;
            }

            if(isMoving)
            {
                var pos = Input.mousePosition;

                var ray = Camera.main.ScreenPointToRay(pos);
                if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                    if(hit.collider.gameObject.Equals(inputField))
                        Move(hit.point);
            }
        }
    }
}

