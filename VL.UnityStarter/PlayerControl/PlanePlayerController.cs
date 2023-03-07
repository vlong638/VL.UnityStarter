using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizontalTurnSpeed = 10.0f;
    public float verticalTurnSpeed = 20.0f;
    public float rotateSpeed = 5.0f;
    public float horizontalInput;
    public float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput= Input.GetAxis("Horizontal");
        verticalInput= Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
        // transform.Translate(Vector3.forward*Time.deltaTime*verticalTurnSpeed*verticalInput);
        // transform.Translate(Vector3.right*Time.deltaTime*horizontalTurnSpeed*horizontalInput);
        transform.Rotate(Vector3.left,rotateSpeed*Time.deltaTime*speed*verticalInput);
        transform.Rotate(Vector3.up,rotateSpeed*Time.deltaTime*speed*horizontalInput);
    }
}
