
using UnityEngine;

public class PuzzleProgress : MonoBehaviour
{
    [Header("Discovered Symbols")]

    [SerializeField]
    private string[] discoveredSymbols = new string[3];

    private bool[] symbolDiscovered = new bool[3];


    public void RegisterSymbol(int statueIndex, string symbol)
    {
        if (statueIndex < 0 || statueIndex >= 3)
            return;

        if (string.IsNullOrEmpty(symbol))
            return;

        discoveredSymbols[statueIndex] = symbol;

        symbolDiscovered[statueIndex] = true;

        Debug.Log("Symbol Discovered: " + symbol);
    }


    public string[] GetDiscoveredSequence()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!symbolDiscovered[i])
            {
                Debug.LogWarning("Not all symbols have been discovered!");
                return null;
            }
        }

        return (string[])discoveredSymbols.Clone();
    }


    public bool AllSymbolsDiscovered()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!symbolDiscovered[i])
                return false;
        }

        return true;
    }


    public void ResetProgress()
    {
        for (int i = 0; i < 3; i++)
        {
            discoveredSymbols[i] = null;
            symbolDiscovered[i] = false;
        }

        Debug.Log("Puzzle Progress Reset.");
    }
}
