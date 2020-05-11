using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanelManager : MonoBehaviour
{
    private int currentPage = 1;
    [SerializeField] private int totalPages;

    private RectTransform panel;
    private Vector2 panelMinPosition;
    private Vector2 panelMaxPosition;

    private RectTransform canvas;
    private float canvasWidth; 

    private void Start()
    {
        panel = GetComponent<RectTransform>();
        panelMinPosition = panel.offsetMin;
        panelMaxPosition = panel.offsetMax;

        canvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        canvasWidth = canvas.rect.width;
    }

    private void Update()
    {
        panel.offsetMin = Vector2.Lerp(panel.offsetMin, panelMinPosition, Time.deltaTime * 5f);
        panel.offsetMax = Vector2.Lerp(panel.offsetMax, panelMaxPosition, Time.deltaTime * 5f);
    }

    public void NextPage()
    {
        if (currentPage != totalPages)
        {
            
            panelMinPosition += new Vector2(-740, 0);
            panelMaxPosition += new Vector2(-740, 0);
            /*
            panelMinPosition += new Vector2(-canvasWidth, 0);
            panelMaxPosition += new Vector2(-canvasWidth, 0);
            */
            currentPage++;
        }
    }

    public void PreviousPage()
    {
        if (currentPage != 1)
        {
            
            panelMinPosition += new Vector2(740, 0);
            panelMaxPosition += new Vector2(740, 0);
            /*
            panelMinPosition += new Vector2(canvasWidth, 0);
            panelMaxPosition += new Vector2(canvasWidth, 0);
            */
            currentPage--;
        }
    }
}
