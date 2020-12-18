using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followImage : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var newPos = GameObject.Find("ImageTarget2").transform.position;
        var newOri = GameObject.Find("ImageTarget2").transform.rotation;
        transform.position = newPos;
        transform.rotation = newOri;
    }
}
