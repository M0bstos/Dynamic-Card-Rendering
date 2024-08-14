using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{

    [SerializeField] private RawImage Scrolling_Back;
    [SerializeField] private float x , y ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the scrolling background texture's UV position based on the x and y movement speed, creating a continuous scrolling effect
        Scrolling_Back.uvRect = new Rect(Scrolling_Back.uvRect.position + new Vector2(x, y) * Time.deltaTime, Scrolling_Back.uvRect.size);
    }
}
