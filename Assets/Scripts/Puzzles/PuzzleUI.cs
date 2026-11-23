
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PuzzleUI : MonoBehaviour
{
    [Header("UI References")]

    [SerializeField]
    private GameObject puzzlePanel;

    [SerializeField]
    private TMP_Text messageText;

    [Header("Settings")]

    [SerializeField]
    private float messageDuration = 2f;


    private Coroutine messageCoroutine;


    public void ShowMessage(string message)
    {
        if (messageText == null)
            return;

        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageCoroutine = StartCoroutine(DisplayMessage(message));
    }


    private IEnumerator DisplayMessage(string message)
    {
        if (puzzlePanel != null)
            puzzlePanel.SetActive(true);

        messageText.text = message;

        yield return new WaitForSeconds(messageDuration);

        messageText.text = "";

        if (puzzlePanel != null)
            puzzlePanel.SetActive(false);

        messageCoroutine = null;
    }


    public void ShowPuzzleSolved()
    {
        ShowMessage("Puzzle Solved!");
    }


    public void ShowWrongAnswer()
    {
        ShowMessage("Wrong Answer! Try Again.");
    }


    public void ShowSymbolDiscovered()
    {
        ShowMessage("A Hidden Symbol Has Been Discovered!");
    }
}
