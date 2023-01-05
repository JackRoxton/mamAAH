using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource source = null;
    [SerializeField]
    AudioClip footsteps= null, scratching = null;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("AudioManager instance not found");

            return instance;
        }
    }
    void Awake()
    {
        if (instance)
            Destroy(instance.gameObject);
        instance = this;
        DontDestroyOnLoad(this);
    }

    //jouer les bruits d'ambience
    public void PlayAmbient()
    {

    }

    public void PlayScratching()
    {
        source.PlayOneShot(scratching);
    }

    public void PlayFootsteps()
    {
        source.PlayOneShot(footsteps);
    }
}
