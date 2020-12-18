using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public static float AIdifficulty = 0.5f;
    public Transform Ball;
    public Transform ScalingObject;
    public Transform ImageTarget2;
    [Range(0,1)]
    public static float skill=0.08f;

    void Start()
    {
        if (PlayerPrefs.HasKey("difficulty"))
        {
            switch (PlayerPrefs.GetInt("difficulty"))
            {
                case 0:
                    AIController.AIdifficulty = 0.5f;
                    return;
                case 1:
                    AIController.AIdifficulty = 1f;
                    return;
                case 2:
                    AIController.AIdifficulty = 2f;
                    return;
            }
        }
        else 
        {
            AIdifficulty = 0.5f;
        }
    }

    public static void ResetSkill()
    {
        skill = Random.Range(0.03f, 0.3f)*AIdifficulty;
        Debug.Log(AIdifficulty);
    }

    void Update()
    {
        ScalingObject.position = Vector3.zero;
        ScalingObject.rotation = Quaternion.Euler(Vector3.zero);

        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(transform.position.x, Ball.position.x, skill);
        transform.position = newPos;

        ScalingObject.position = ImageTarget2.position;
        ScalingObject.rotation = ImageTarget2.rotation;
    }
}
