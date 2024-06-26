using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class TarotCard
{
    public Sprite image;
    public string comment;
}

public class Scene3 : MonoBehaviour
{
    [SerializeField] List<TarotCard> cards; // List of tarot cards
    [SerializeField] SpriteRenderer[] card_Slot; // Array of sprite renderers for card slots
    [SerializeField] Text card_Comments; // Single UI Text component for all card comments
    [SerializeField] Button backButton; // Button for going back to the main scene
    [SerializeField] Button drawButton; // Button for drawing new cards

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;

        // Assign button click listeners
        backButton.onClick.AddListener(() => SceneManager.LoadScene("SampleScene"));
        drawButton.onClick.AddListener(() => Shuffle_Cards());

        ShuffleCards();
    }

    public void Shuffle_Cards()
    {
        ShuffleCards();
    }

    void ShuffleCards()
    {
        HashSet<int> usedIndices = new HashSet<int>();
        string combinedComments = "";

        for (int i = 0; i < card_Slot.Length; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(0, cards.Count);
            } while (usedIndices.Contains(rand));

            usedIndices.Add(rand);

            card_Slot[i].sprite = cards[rand].image;
            combinedComments += cards[rand].comment + "\n"; // Combine comments with newline
        }

        card_Comments.text = combinedComments; // Set the combined comments to the single Text component
    }
}
