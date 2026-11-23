
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    [Header("Puzzle Settings")]

    [SerializeField]
    private string[] correctSymbols = new string[3];

    [SerializeField]
    private StatueReveal[] statuesToReveal = new StatueReveal[3];

    private string[] selectedSymbols = new string[3];

    private bool[] statueSelected = new bool[3];

    private bool puzzleSolved = false;

    [Header("Puzzle Events")]

    public UnityEvent onPuzzleSolved;


    public void SelectSymbol(int statueIndex, string symbol)
    {
        if (puzzleSolved)
            return;

        if (statueIndex < 0 || statueIndex >= 3)
            return;

        selectedSymbols[statueIndex] = symbol;

        statueSelected[statueIndex] = true;

        CheckPuzzle();
    }


    private void CheckPuzzle()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!statueSelected[i])
                return;
        }

        for (int i = 0; i < 3; i++)
        {
            if (selectedSymbols[i] != correctSymbols[i])
            {
                Debug.Log("Incorrect Symbols! Try Again.");

                ResetPuzzle();

                return;
            }
        }

        SolvePuzzle();
    }


    private void SolvePuzzle()
    {
        puzzleSolved = true;

        Debug.Log("First Puzzle Solved!");

        foreach (StatueReveal statue in statuesToReveal)
        {
            if (statue != null)
            {
                statue.RevealSymbol();
            }
        }

        onPuzzleSolved?.Invoke();
    }


    public void ResetPuzzle()
    {
        for (int i = 0; i < 3; i++)
        {
            selectedSymbols[i] = null;

            statueSelected[i] = false;
        }
    }
}
