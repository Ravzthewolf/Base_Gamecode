using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Character_Movement : MonoBehaviour
{
    //Reference to the day/night cycle controller
    public DayNightCycle dayNightCycle;
    
    //Speed of NPC movement during the day and night
    public float daySpeed = 5f;
    public float nightSpeed = 2f;

    //Current movement speed
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if it's day or night
        if (dayNightCycle.IsDaytime())
        {
            //Set movement speed to day speed
            currentSpeed = daySpeed;
        }
        else
        {
            //Set movement speed to night speed
            currentSpeed = nightSpeed;
        }

        //Move the NPC
        MoveNPC();
    }

    //Method to move the NPC
    void MoveNPC()
    {
        //Calculate movement amount based on current speed and deltaTime
        float movementAmount = currentSpeed * Time.deltaTime;

        //Move the NPC forward
        transform.Translate(Vector3.forward * movementAmount);
    }
}
