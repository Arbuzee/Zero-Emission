using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopulationFeedback : MonoBehaviour
{

    [SerializeField] private Texture happySmileyImg;
    [SerializeField] private float displayTime;
    [SerializeField] private GameObject PopUpImage;
    [SerializeField] private int ImageChance = 15;
    [SerializeField] private float ImageOffset = 50f;



    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
        EventManager.Instance.RegisterListener<CO2Change>(OnCO2Change);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnBuildingSwap(BuildingSwapEvent eve)
    {
        
    }

    private void OnCO2Change(CO2Change eve)
    {
        //create chance of reaction
        int random = Random.Range(0, ImageChance);
        if (eve.CO2AdjustmentValue < 0 && random < 1)
        {
            //happy reaction from folks, trigger the smileys!
            //Vector3 position = gameObject.transform.position;
            //PopUpManager.Instance.ShowImage(happySmileyImg, position, displayTime);
            ShowImage();
        }
    }

    private void ShowImage() {
        //GameObject imageObj = Instantiate(PopUpImage, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        GameObject imageObj = Instantiate(PopUpImage, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.GetChild(0).transform);
        imageObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + ImageOffset, gameObject.transform.position.z);
        imageObj.GetComponent<RawImage>().texture = happySmileyImg;
        Destroy(imageObj, displayTime);
    }

}
