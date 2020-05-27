using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
    private int currentPage = 1;
    private int totalPages;
    [SerializeField] Image[] buildingPages;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;

    private void Start()
    {
        totalPages = buildingPages.Length;
        print(totalPages);
        if(buildingPages.Length > 0 && buildingPages != null)
        {
            foreach(Image i in buildingPages)
            {
                i.gameObject.SetActive(false);
            }
            buildingPages[0].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (currentPage == totalPages || totalPages == 1)
        {
            nextButton.interactable = false;
        }

        if (currentPage == 1 || totalPages == 1)
        {
            previousButton.interactable = false;
        }

        if(totalPages != currentPage)
        {
            nextButton.interactable = true;
        }

        if (currentPage - 1 != 0)
        {
            previousButton.interactable = true;
        }
    }

    public void NextPage()
    {
            buildingPages[currentPage - 1].gameObject.SetActive(false);
            buildingPages[currentPage].gameObject.SetActive(true);
            currentPage++;
    }

    public void PreviousPage()
    {
        buildingPages[currentPage - 1].gameObject.SetActive(false);
        buildingPages[currentPage - 2].gameObject.SetActive(true);
        currentPage--;
    }
}
