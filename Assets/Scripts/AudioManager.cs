using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip grabAudio;
    [SerializeField]
    AudioClip shopAudio;
    public static AudioManager instance;
    public enum AudioClipType { grapAudio, shopAudio };

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance );
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClipType type)
    {
        if(audioSource != null)
        {
            AudioClip clip = null;
            if(type == AudioClipType.grapAudio)
            {
                clip = grabAudio;
            }else if (type == AudioClipType.shopAudio) 
            { 
                clip = shopAudio; 
            }
            audioSource.PlayOneShot(clip);
        }


    }

}
