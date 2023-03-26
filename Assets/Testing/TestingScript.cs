using GokboerueTools;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Gokboerue.CreatePopupText(Gokboerue.G_GetMousePosition(), Random.Range(100,1000).ToString());
        }
    }
}
