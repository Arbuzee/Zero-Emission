using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupHandler : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
