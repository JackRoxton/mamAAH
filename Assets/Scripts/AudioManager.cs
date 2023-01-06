using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource source = null;

    //mère et monstre
    [SerializeField]
    AudioClip footsteps= null, scratching = null;

    //ambiance
    [SerializeField]
    AudioClip creak = null, wood = null, window = null;

    float scratchTimer = 0;
    float ambientTimer = 8;

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

    private void Update()
    {
        if(scratchTimer > 0)
        scratchTimer -= Time.deltaTime;

        ambientTimer -= Time.deltaTime;
        if (ambientTimer <= 0)
        {
            ambientTimer = 8 + Random.Range (-2,3);
            PlayAmbient();
        }
    }

    //jouer les bruits d'ambience au hasard
    public void PlayAmbient()
    {
        int rand = Random.Range(0,3);
        if (rand == 0)
            source.PlayOneShot(creak);
        else if (rand == 1)
            source.PlayOneShot(wood);
        else if (rand == 2)
            source.PlayOneShot(window);

    }

    public void PlayScratching()
    {
        if (scratchTimer > 0)
            return;

        scratchTimer = scratching.length;
        source.PlayOneShot(scratching);
    }

    public void PlayFootsteps()
    {
        source.PlayOneShot(footsteps);
    }

    public void Play(AudioClip c)
    {
        source.PlayOneShot(c);
        Debug.Log("Dead);");
    }

}
