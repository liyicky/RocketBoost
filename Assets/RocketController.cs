using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    Rigidbody rb;
    AudioSource auds;
    [SerializeField] float mainThrust = 10f;
    [SerializeField] float rscThrust = 100f;

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
            rb.AddRelativeForce(Vector3.up * mainThrust);
            if (!auds.isPlaying) auds.Play();
        }
        else
        {
            auds.Stop();
        }

        handleRotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Touched a friendly");
                break;

            default:
                print("Dead");
                break;
        }

    }

    private void handleRotation()
    {
        rb.freezeRotation = true; // stop physics

        float rotationThisFrame = rscThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rb.freezeRotation = false; // start physics
    }

}
