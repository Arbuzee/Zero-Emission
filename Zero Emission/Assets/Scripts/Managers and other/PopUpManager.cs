using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



//PopUpManager can be called to display several things such as the popupwindows, but also ai reaction images and other.
public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject PopupWindow;
    [SerializeField] private GameObject PopUpImage;
   

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

    public void ShowImage(Texture img, Vector3 position, float displayTime) {
        /*
        RawImage imageObj = gameObject.AddComponent<RawImage>();
        imageObj.texture = img;
        imageObj.SetNativeSize();
        //imageObj.rectTransform.localScale = new Vector3(100f, 100f, 0f);
        */

        GameObject imageObj = Instantiate(PopUpImage, position, gameObject.transform.rotation, gameObject.transform);
        imageObj.transform.position = position;
        imageObj.GetComponent<RawImage>().texture = img;
        Destroy(imageObj, displayTime);
    }

}
