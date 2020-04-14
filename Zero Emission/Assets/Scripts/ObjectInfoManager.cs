using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectInfoManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject PopupWindow;
    [SerializeField] private float popUpTime;
    [SerializeField] private string title;
    [TextArea(15,15)]
    [SerializeField] private string description;



    public void OnPointerClick(PointerEventData eventData)
    {
        ShowPopupWindow();
    }

    private void ShowPopupWindow()
    {
        print("Showing popup");
        GameObject obj = Instantiate(PopupWindow, transform.root);
        obj.GetComponent<PopupHandler>().titleText.text = title;
        obj.GetComponent<PopupHandler>().descriptionText.text = description;
        obj.transform.position = Input.mousePosition;
    }
}
