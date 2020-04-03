using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : Mover
{
    #region Editor    
    [SerializeField]
    private GameObject arrow;
    #endregion

    private float baseArrowSize;
    private float baseDistanceToArrow;

    protected override void Awake()
    {
        base.Awake();
        baseArrowSize = arrow.transform.localScale.x;
        baseDistanceToArrow = (arrow.transform.position - transform.position).magnitude;

        input.Throw += () => arrow.SetActive(false);
    }

    protected override void Move(Vector3 position)
    {
        transform.position = WorldToGameFieldPoint(position);
        DrawArrow();
    }

    private void DrawArrow()
    {
        arrow.SetActive(true);
        //rotate arrow
        var targetPoint = new Vector3(arrow.transform.position.x, transform.position.y, arrow.transform.position.z) - transform.position;
        Quaternion.LookRotation(targetPoint, Vector3.up).ToAngleAxis(out var angle, out Vector3 axis);
        arrow.transform.rotation = Quaternion.Euler(90, angle + 90, 0);

        //calculate size
        var scale = arrow.transform.localScale;
        var multiplier = (arrow.transform.position - transform.position).magnitude / baseDistanceToArrow;
        arrow.transform.localScale = new Vector3(baseArrowSize * multiplier, scale.y, scale.z);
    }

}
