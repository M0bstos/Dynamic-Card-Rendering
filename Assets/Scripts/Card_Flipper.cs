using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Card_Flipper : MonoBehaviour
{
    public float x, y, z;                // Rotation angles for the flip
    public GameObject Card_Back;         
    public bool CardBackActive;          
    public int timer;                    

    void Start()
    {
        CardBackActive = false;          // Initialize the card back as inactive
    }

    // Update is called once per frame
    void Update()
    {
        // Starts the flip when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            StartFlip();
        }
    }

    public void StartFlip()
    {
        StartCoroutine(CalculateFlip());
    }

    // Toggles between showing and hiding the card back
    public void Flip()
    {
        if (CardBackActive)
        {
            Card_Back.SetActive(false);  
            CardBackActive = false;
        }
        else
        {
            Card_Back.SetActive(true);
            CardBackActive = true;

            // Proper orientation of the back of the card
            Card_Back.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    // Coroutine for smooth rotation
    IEnumerator CalculateFlip()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.001f); 
            transform.Rotate(new Vector3(x, y, z));   // Rotates the card

            timer++;

            // toggles the back or front of the card halfway through the flip
            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }

        timer = 0;
    }
}
