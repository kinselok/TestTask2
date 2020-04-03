using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

class TouchInput : MonoBehaviour, IInputHandler
{
    #region Editor
    [SerializeField]
    private GameObject inputField;
    #endregion

    private int fingerID = 0;

    public event Action<Vector3> Move;
    public event Action Throw;

    private bool isOnUI = false;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
                isOnUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);
            if(!isOnUI)
            {               
                var ray = Camera.main.ScreenPointToRay(touch.position);
                Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
                if(hit.collider.gameObject.Equals(inputField))
                    Move(hit.point);

                if(touch.phase == TouchPhase.Ended)
                    Throw();
            }
        }
    }
}

