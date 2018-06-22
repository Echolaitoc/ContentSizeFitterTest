using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextToggle : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string textOne;
    [SerializeField, TextArea(3, 10)] private string textTwo;

    private TextMeshProUGUI textMesh;
    private bool isTextOne = true;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void ToggleText()
    {
        if (textMesh == null)
        {
            return;
        }
        isTextOne = !isTextOne;
        textMesh.text = (isTextOne ? textOne : textTwo);
    }
}
