
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class SequencePuzzle : MonoBehaviour
{
    [Header("Puzzle References")]

    [SerializeField]
    private PuzzleProgress puzzleProgress;

    [Header("Puzzle Settings")]

    [SerializeField]
    private int requiredSymbols = 3;

    private string[] correctSequence;

    private List<string> playerSequence = new List<string>();

    private bool puzzleSolved = false;

    [Header("Puzzle Events")]

    public UnityEvent onSequenceSolved;


    private void Start()
    {
        if (puzzleProgress == null)
        {
            Debug.LogError("Puzzle Progress is not assigned!");
            return;
        }

        correctSequence = puzzleProgress.GetDiscoveredSequence();

        if (correctSequence == null)
        {
            Debug.LogError("The first puzzle is not completed!");
        }
    }


    public void SelectSequenceSymbol(string symbol)
    {
        if (puzzleSolved || correctSequence == null)
            return;

        if (string.IsNullOrEmpty(symbol))
            return;

        playerSequence.Add(symbol);

        Debug.Log("Selected: " + symbol);

        CheckSequence();
    }


    private void CheckSequence()
    {
        int currentIndex = playerSequence.Count - 1;

        if (playerSequence[currentIndex] != correctSequence[currentIndex])
        {
            Debug.Log("Wrong Sequence! Try Again.");

            ResetSequence();

            return;
        }

        if (playerSequence.Count == requiredSymbols)
        {
            SolvePuzzle();
        }
    }


    private void SolvePuzzle()
    {
        puzzleSolved = true;

        Debug.Log("Second Puzzle Solved!");

        onSequenceSolved?.Invoke();
    }


    public void ResetSequence()
    {
        playerSequence.Clear();

        Debug.Log("Sequence Reset.");
    }
}
