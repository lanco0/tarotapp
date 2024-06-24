using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene5 : MonoBehaviour
{
    [SerializeField] List<TarotCard> cards; // List of tarot cards with images and comments
    [SerializeField] SpriteRenderer[] card_Slot; // Array of sprite renderers for card slots
    [SerializeField] Text card_Comments; // Single UI Text component for all card comments
    [SerializeField] Button backButton; // Button for going back to the main scene
    [SerializeField] Button drawButton; // Button for drawing new cards

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        animator = GetComponent<Animator>();
        Invoke("PlayStartAnim", 0.2f);

        // Assign button click listeners
        backButton.onClick.AddListener(() => SceneManager.LoadScene("SampleScene"));
        drawButton.onClick.AddListener(() => Shuffle_Cards());
    }

    // Update is called once per frame
    void Update()
    {
        // Empty update method; consider removing if not used later
    }

    public void Shuffle_Cards()
    {
        StartCoroutine(ResetAnim());
    }

    void PlayStartAnim()
    {
        animator.Play("Shuffle");
        ShuffleCards();
    }

    IEnumerator ResetAnim()
    {
        animator.Play("Reset");
        yield return new WaitForSeconds(2f); // Adjust the wait time according to the reset animation duration
        animator.Play("Shuffle");
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
