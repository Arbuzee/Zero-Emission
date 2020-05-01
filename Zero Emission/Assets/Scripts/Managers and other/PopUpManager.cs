using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject PopupWindow;
   

    public static PopUpManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(this);
        }
    }

    public void ShowPopupWindow(string title, string description, float time, Vector3 position)
    {
        print("Showing popup");
        GameObject obj = Instantiate(PopupWindow, gameObject.transform);
        obj.GetComponent<PopupHandler>().titleText.text = title;
        obj.GetComponent<PopupHandler>().descriptionText.text = description;
        Debug.Log("position: " + position);
    }

   
    
}
