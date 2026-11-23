
using UnityEngine;

public class StatueSymbol : MonoBehaviour
{
    [Header("Statue Settings")]

    [SerializeField]
    private int statueIndex;

    [SerializeField]
    private string symbol;

    [Header("Puzzle Reference")]

    [SerializeField]
    private PuzzleManager puzzleManager;


    public void SelectStatue()
    {
        if (puzzleManager == null)
        {
            Debug.LogWarning("Puzzle Manager is not assigned!");
            return;
        }

        puzzleManager.SelectSymbol(statueIndex, symbol);

        Debug.Log("Selected Symbol: " + symbol);
    }
}
 