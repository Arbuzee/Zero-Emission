using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    [SerializeField]private AudioSource musicSrc;
    [SerializeField]private AudioSource sfxSrc;

    private ArrayList audioObjects;


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

    private void Start()
    {
        EventManager.Instance.RegisterListener<BuildingSwapEvent>(OnBuildingSwap);
        
    }

    public void SetMusic(bool on) {
        if (on)
        {
            musicSrc.Play();
            sfxSrc.Play();
        }
        else {
            musicSrc.Stop();
            sfxSrc.Stop();
        }
        
    }

    private void OnBuildingSwap(BuildingSwapEvent eve) {
        //add ref to audioSources of new added building on map to list here so they may be controlled from manager. 
        AudioSource sound;
        if (eve.newBuilding.TryGetComponent<AudioSource>(out sound))
            audioObjects.Add(sound);

    }


}
