using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private Variables
    //Einkabreytur
    private float speed = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    // Start er kallað fyrir fyrstu rammauppfærslu
    void Start()
    {
        
    }

    // Update is called once per frame
    // Uppfærsla er kölluð einu sinni í hvern ramma
    void Update()
    {
        // this is where we get player input
        // þetta er þar sem við fáum inntak leikmanna
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        // Við færum farartækið áfram
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // We turn the vehicle
        // Við snúum ökutækinu
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}







