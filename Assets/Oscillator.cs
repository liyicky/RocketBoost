using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] 

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movement;
    [Range(0,1)] [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;
    Vector3 startingPos;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; //grows continually from 0
        const float tau = Mathf.PI * 2; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        transform.position = startingPos + (movement * movementFactor);
    }
}
