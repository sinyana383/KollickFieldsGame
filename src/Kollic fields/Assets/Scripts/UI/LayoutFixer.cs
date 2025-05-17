using UnityEngine;
using UnityEngine.UI;

public class LayoutFixer : MonoBehaviour
{
    void Start()
    {
        FixContentSizeFitter();
    }

    void FixContentSizeFitter()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.transform as RectTransform);
    }
}
