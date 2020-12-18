using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerPlayerController : MonoBehaviour
{
    public Camera playerCam;
    public Transform ScalingObject;
    public Transform ImageTarget2;
    public Transform ImageTarget;

    void Update()
    {
        //Debug.Log(DefaultTrackableEventHandler.markerDetected);
        if (Input.touchCount != 1)
        {
            if (IsMarkerDetected.markerDetected)
            {
                transform.position = ImageTarget.position;
                ResetScalePos();
                transform.position = new Vector3(transform.position.x, 0, -2);
                SetScalePos();
            }



            //else
            //{
            //    ResetScalePos();
            //    transform.position = new Vector3(0, 0, -2);
            //    SetScalePos();
            //}
            return;
        }
        else
        {
            var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            var hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name != "Bounds North")
                    return;
                transform.position = hitInfo.point;
                ResetScalePos();
                transform.position = new Vector3(transform.position.x, 0, -2);
                SetScalePos();
            }
        }

    }
    //void Update()
    //{
    //    //Debug.Log(DefaultTrackableEventHandler.markerDetected);
    //    if (Input.touchCount != 1)
    //    {
    //        transform.position = ImageTarget.position;

    //        ResetScalePos();
    //        transform.position = new Vector3(transform.position.x, 0, -2);
    //        SetScalePos();
    //        return;
    //    }
    //    else
    //    {
    //        var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
    //        var hitInfo = new RaycastHit();
    //        if (Physics.Raycast(ray, out hitInfo))
    //        {
    //            if (hitInfo.transform.name != "Bounds North")
    //                return;
    //            transform.position = hitInfo.point;
    //            ResetScalePos();
    //            transform.position = new Vector3(transform.position.x, 0, -2);
    //            SetScalePos();
    //        }
    //    }

    //}
    void ResetScalePos()
    {
        ScalingObject.position = Vector3.zero;
        ScalingObject.rotation = Quaternion.Euler(Vector3.zero);
    }

    void SetScalePos()
    {
        ScalingObject.position = ImageTarget2.position;
        ScalingObject.rotation = ImageTarget2.rotation;
    }
}
