
using UnityEngine;
using System.Collections;

public class StatueReveal : MonoBehaviour
{
    [Header("Statue Settings")]

    [SerializeField]
    private GameObject statue;

    [SerializeField]
    private GameObject hiddenSymbol;

    [Header("Progress Settings")]

    [SerializeField]
    private PuzzleProgress puzzleProgress;

    [SerializeField]
    private int statueIndex;

    [SerializeField]
    private string revealedSymbol;

    [Header("Animation Settings")]

    [SerializeField]
    private float disappearDuration = 2f;

    [SerializeField]
    private float disappearHeight = 2f;

    [SerializeField]
    private float symbolRevealDelay = 0.5f;

    private bool isRevealed = false;


    public void RevealSymbol()
    {
        if (isRevealed)
            return;

        if (statue == null || hiddenSymbol == null)
            return;

        isRevealed = true;

        StartCoroutine(RevealSequence());
    }


    private IEnumerator RevealSequence()
    {
        Vector3 startPosition = statue.transform.position;

        Vector3 targetPosition = startPosition +
                                 Vector3.up * disappearHeight;

        float elapsedTime = 0f;

        while (elapsedTime < disappearDuration)
        {
            elapsedTime += Time.deltaTime;

            float progress = Mathf.Clamp01(
                elapsedTime / disappearDuration
            );

            statue.transform.position = Vector3.Lerp(
                startPosition,
                targetPosition,
                progress
            );

            yield return null;
        }

        statue.SetActive(false);

        yield return new WaitForSeconds(symbolRevealDelay);

        hiddenSymbol.SetActive(true);

        if (puzzleProgress != null)
        {
            puzzleProgress.RegisterSymbol(
                statueIndex,
                revealedSymbol
            );
        }

        Debug.Log("Hidden Symbol Revealed: " + revealedSymbol);
    }
}
