using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCam;
    void Update()
    {
        if (Input.touchCount != 1)
        {
            return;
        }
        var ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        var hitInfo = new RaycastHit();
        if (Physics.Raycast(ray,out hitInfo))
        {
            if (hitInfo.transform.name != "Bounds North")
                return;
            var newPos = transform.position;
            newPos.x = hitInfo.point.x;
            transform.position = newPos;
        }
        
    }
}
