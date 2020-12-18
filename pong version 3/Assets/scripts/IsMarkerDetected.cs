using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMarkerDetected : DefaultTrackableEventHandler
{
    public static bool markerDetected;
    // Start is called before the first frame update
    new void Start()
    {
        markerDetected = true;
    }

    protected override void OnTrackingFound()
    {
        //base.OnTrackingFound();
        markerDetected = true;
    }


    protected override void OnTrackingLost()
    {
        //base.OnTrackingLost();
        markerDetected = false;
    }
}
