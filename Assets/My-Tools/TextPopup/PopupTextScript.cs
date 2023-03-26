using UnityEngine;
using TMPro;
using static GokboerueTools.GameAssets;
using GokboerueTools;

public class PopupTextScript : MonoBehaviour
{
    public static PopupTextScript Create(Vector3 position, string text, Color color)
    {
        Transform textPopupTransform = GetObjectFromPool(AssetData.PopupText, position, Quaternion.identity).transform;

        PopupTextScript popupText = textPopupTransform.GetComponent<PopupTextScript>();
        popupText.Setup(text, color);

        return popupText;
    }
    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 0.7f;

    private float disappearTimer; 
    private TextMeshPro TextMesh;
    private Color textColor;
    private Vector3 moveVector;
    private void Awake()
    {
        TextMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(string text, Color color)
    {
        TextMesh.SetText(text);
        TextMesh.color = color;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        sortingOrder++;
        TextMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(.7f, 1) * 10f;
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;
        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            TextMesh.color = textColor;

            if (textColor.a < 0)
            {
                ReturnObjectToPool(gameObject);
            } 
        }
    }
}

