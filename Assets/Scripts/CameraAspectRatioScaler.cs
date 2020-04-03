using UnityEngine;


public class CameraAspectRatioScaler : MonoBehaviour
{
    #region Editor
    [SerializeField]
    private Vector2 ReferenceResolution;
    [SerializeField]
    private Vector3 ZoomFactor = Vector3.one;
    #endregion

    void Start()
    {

        if(ReferenceResolution.y == 0 || ReferenceResolution.x == 0)
            return;

        var refRatio = ReferenceResolution.x / ReferenceResolution.y;
        var ratio = (float)Screen.width / (float)Screen.height;

        transform.position = transform.position + transform.forward * (1f - refRatio / ratio) * ZoomFactor.z
                                            + transform.right * (1f - refRatio / ratio) * ZoomFactor.x
                                            + transform.up * (1f - refRatio / ratio) * ZoomFactor.y;
    }
}
