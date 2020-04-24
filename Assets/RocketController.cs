using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    Rigidbody rb;
    AudioSource auds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        auds = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
            if (!auds.isPlaying) auds.Play();
        }
        else
        {
            auds.Stop();
        }

        handleRotation();
    }

    private void handleRotation()
    {
        rb.freezeRotation = true; // stop physics

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

        rb.freezeRotation = false; // start physics
    }

}
