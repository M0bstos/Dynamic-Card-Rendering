using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Draw_Cards : MonoBehaviour
{
    public GameObject Card;
    public GameObject Scrolling_Background;

    // Array of Card Values and Suits
    private string[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private string[] suits = { "c", "h", "s", "d" };

    void Start()
    {
        Draw();
    }

    void Draw()
    {
        // Two nested for loops to iterate through each of the 52 suit and value combinations
        for (int suitIndex = 0; suitIndex < suits.Length; suitIndex++)
        {
            for (int valueIndex = 0; valueIndex < values.Length; valueIndex++)
            {
                // Instantiates the Card
                GameObject displayCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);

                // Displays the Card by Adding it as a child to the Background
                displayCard.transform.SetParent(Scrolling_Background.transform, false);

                // Uses the nested for loops to concatenate the suit and value for the card
                string cardValue = $"{values[valueIndex]}{suits[suitIndex]}";

                // Find the Text Component for the Card
                TextMeshProUGUI cardValueText = displayCard.GetComponentInChildren<TextMeshProUGUI>();

                if (cardValueText != null)
                {
                    // Adds the Card Value to the Card
                    cardValueText.text = cardValue;
                }
            }
        }
    }
}
