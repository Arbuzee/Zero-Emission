using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    private AudioSource aSrc;

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
        aSrc = GetComponent<AudioSource>();
    }

    public void SetMusic(bool on) {
        if (on)
        {
            aSrc.Play();
        }
        else {
            aSrc.Stop();
        }
        
    }


}
