using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    
    Vector3 velocity;
    [Range(0, 1)]
    Rigidbody rb;
    static float speedFactor = 45f;
    public static float speed = 0.05f * speedFactor;
    public Transform ScalingObject;
    public Transform ImageTarget2;
    public AudioSource hitPaddle;
    public AudioSource hitSides;
    public AudioSource outBound;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var aSources = GetComponents<AudioSource>();
        hitPaddle = aSources[0];
        hitSides = aSources[1];
        outBound = aSources[2];
        ResetBall();
    }

    void ResetBall()
    {
        ResetScalePos();

        transform.position = Vector3.zero;

        //var newPos = GameObject.Find("ImageTarget2").transform.position;
        //transform.position = new Vector3(newPos.x, newPos.y + 0.21f, newPos.z);

        float z = (Random.Range(0, 2)) *2f - 1f;
        float x = ((Random.Range(0, 2)) *2f - 1f) * Random.Range(1f, 5f);
        velocity = new Vector3(x, 0, z);

        SetScalePos();
    }

    /*
    void ResetYaxis()
    {
        var newPos = GameObject.Find("ImageTarget2").transform.position;
        transform.position = new Vector3(transform.position.x, newPos.y + 0.21f, transform.position.z);
    }*/

    // Update is called once per frame
    void Update()
    {
        ResetScalePos();
        //////var newRot = GameObject.Find("ScalingObject").transform.rotation;
        //var newRotate = Quaternion.LookRotation(newRot);
        velocity = velocity.normalized * speed;
        ////////var veloc = newRot * velocity;

        ////////transform.position += veloc;

        transform.position += velocity * Time.deltaTime;

        Vector3 left = Vector3.Cross(velocity, Vector3.up).normalized;
        transform.RotateAround(transform.position, left, speed * -90f * Time.deltaTime);

        SetScalePos();
    }

    void OnCollisionEnter(Collision collision)
    {
        //ScalingObject.position = Vector3.zero;
        //ScalingObject.rotation = Quaternion.Euler(Vector3.zero);
        switch (collision.transform.name)
        {
            /*
            case "Bounds Top":
            case "Bounds Down":
                ResetYaxis();
                return;
            */
            case "Bounds East":
            case "Bounds West":
                hitSides.Play();
                ResetScalePos();
                velocity.x *= -1f;
                SetScalePos();
                return;
            case "Bounds North":
                outBound.Play();
                ShowScore.scoreValue -= 1;
                AIController.ResetSkill();
                ResetBall();
                return;
            case "Bounds South":
                outBound.Play();
                ShowScore.scoreValue += 1;
                AIController.ResetSkill();
                ResetBall();
                return;
            case "Player Paddle":
            case "Computer Paddle":
                hitPaddle.Play();
                ResetScalePos();
                speed = Random.Range(0.06f, 0.1f)* speedFactor;
                    //speed *= 0.3f;
                AIController.ResetSkill();
                velocity.z *= -1f;
                SetScalePos();
                return;
        }
        //var newPosit = ImageTarget2.position;
        //var newOrient = ImageTarget2.rotation;
        //ScalingObject.position = newPosit;
        //ScalingObject.rotation = newOrient;

    }
}
