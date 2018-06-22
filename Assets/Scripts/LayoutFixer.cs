using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutFixer : MonoBehaviour
{
    public void FixLayout()
    {
        StopAllCoroutines();
        StartCoroutine(FixLayoutCoroutine());
    }

    private IEnumerator FixLayoutCoroutine()
    {
        List<VerticalLayoutGroup> verticalLayoutGroups = new List<VerticalLayoutGroup>();
        GetComponentsInChildren<VerticalLayoutGroup>(true, verticalLayoutGroups);

        List<ContentSizeFitter> contentSizeFitters = new List<ContentSizeFitter>();
        GetComponentsInChildren<ContentSizeFitter>(true, contentSizeFitters);

        // --- Enable Layout Components ---

        foreach (var vlg in verticalLayoutGroups)
        {
            vlg.enabled = true;
        }

        contentSizeFitters.Reverse();
        foreach (var csf in contentSizeFitters)
        {
            if (csf.GetComponentsInChildren<ContentSizeFitter>().Length > 1)
            {
                yield return null; // if all content size fitters are updated in the same frame, they do not take into account changes in their children
            }
            csf.enabled = true;
        }

        yield return null;

        // --- Disable Layout Components ---

        foreach (var csf in contentSizeFitters)
        {
            csf.enabled = false;
        }
        foreach (var vlg in verticalLayoutGroups)
        {
            vlg.enabled = false;
        }
    }
}
