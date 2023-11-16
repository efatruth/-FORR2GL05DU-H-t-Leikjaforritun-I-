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
    // Start er kalla� fyrir fyrstu rammauppf�rslu
    void Start()
    {
        
    }

    // Update is called once per frame
    // Uppf�rsla er k�llu� einu sinni � hvern ramma
    void Update()
    {
        // this is where we get player input
        // �etta er �ar sem vi� f�um inntak leikmanna
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward
        // Vi� f�rum farart�ki� �fram
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // We turn the vehicle
        // Vi� sn�um �kut�kinu
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}







