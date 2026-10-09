using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NonogramTiles : MonoBehaviour
{
    //both references to the sprite changing
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    // state the tile is currently in, true being colored, false being uncolored or x
    [SerializeField] private bool State;
    // state its supposed to be
    [SerializeField] private bool TrueState;
    // state for if the tile is an
    [SerializeField] private bool X;

    //reference to the check solution script 
    public Check solution;

    void Start()
    {
        State = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        solution = GameObject.Find("tiles").GetComponent<Check>();
    }

    //this is for left mouse click
    //basically it changes the tile to the oposite state of what it currently is, and also turns of the x state if it was on
    void OnMouseDown()
    {
        X = false;

        if (State == true)
        {
            State = false;
        }
        else
        {
            State = true;
        }
    }

    //this is for right mouse click
    //does the same thing as on mouse down, but for right click, and most of the time it makes the X tile, but if the tile is already an X, it will turn it back to uncolored
    public void OnMouseOver()
    {
        if (X == false && Input.GetMouseButtonDown(1))
        {
            State = false;
            X = true;

        }
        else if (X == true && Input.GetMouseButtonDown(1))
        {
            State = false;
            X = false;

        }
    }

    //this technically doesnt need to be in update, but it was easier to do it this way, and i dont have time to change it rn

    //bascially it changes the sprite or color of the tile depending on what state its in
    void Update()
    {
        //this is like a rly small delay, bc without it the script was freaking out
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Wait());
        }

        if (State)
        {
            spriteRenderer.color = new Color32(65, 72, 51, 255);
            spriteRenderer.sprite = spriteArray[1];
        }

        if (!State)
        {
            spriteRenderer.color = new Color32(204, 191, 163, 255);
            spriteRenderer.sprite = spriteArray[1];
        }

        if (X)
        {
            spriteRenderer.color = new Color32(255, 255, 255, 255);
            spriteRenderer.sprite = spriteArray[0];
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        if (State == TrueState)
        {
            solution.sol += 1;
        }
    }
}
