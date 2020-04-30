using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void DisableMusic()
    {
        SoundManager.Instance.SetMusic(false);
    }

    public void EnableMusic() {
        SoundManager.Instance.SetMusic(true);
    }

}
