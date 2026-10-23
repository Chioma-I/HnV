using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is attached to one main object and handles the solution checking, as well as the win object activation

public class Check : MonoBehaviour
{
    //solution int, it counts if the tile is in correct state
    public int sol;
    public int required;

    //win object, it will be activated when the player wins
    public GameObject wn;


    void Start()
    {
        sol = 0;
    }

    void Update()
    {
        //i coded this pretty weird, but the solution int resets itself to 0 each click, and then each tile sends out if theyre in correct spot or not 
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            if (sol < required)
            {
                sol = 0;
            }
        }

        //when everything is in correct state, the win object will be activated
        if (sol == required)
        {
            wn.SetActive(true);
        }

        // this was added, cuz the solution thing could go over 100 in some specific situations
        if (sol > required)
        {
            sol = 0;
        }
    }
}