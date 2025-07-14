using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rotation : MonoBehaviour
{
    //Speed of rotation
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player presses the left arrow key
        if (Input.GetKwy(KeyCode.LeftArrow))
        {
            //Rotate the object around its y-axis
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        //Check if the player presses the right key
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate the object around its y-axis in the opposite direction
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }
}
