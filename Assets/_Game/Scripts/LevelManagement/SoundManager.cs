using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

namespace TemplateFx
{
    [System.Serializable]
    public class SoundClass
    {
        public string soundName;
        public AudioClip soundSource;
    }

    public class SoundManager : Singleton<SoundManager>
    {
        public List<SoundClass> listOfSoundClasses = new List<SoundClass>();
        private AudioSource audioSource;
        private bool isPlayedSound;

    
        void Start()
        {
            if(audioSource == null)
            {
                AudioSource temporaryAudioSource = GetComponent<AudioSource>();
                if(temporaryAudioSource != null)
                {
                    audioSource = GetComponent<AudioSource>();
                }
                else
                {
                    Debug.Log("AudioSource is null (Template added AudioSource)");
                    audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.playOnAwake = false;
                    
                }
        
            }
        }

        public void SoundPlay(string audioName)
        {
            isPlayedSound = false;
            foreach(SoundClass soundClass in listOfSoundClasses)
            {
                if(audioName == soundClass.soundName)
                {
                    if(soundClass.soundSource != null)
                    {
                        audioSource.PlayOneShot(soundClass.soundSource);
                        isPlayedSound = true;
                    }
                    else
                    {
                        Debug.Log(audioName + " source is NULL");
                    }
                   
                }
            }
            if(!isPlayedSound)
            {
                Debug.Log(">" + audioName + "< not valuable in list");
            }
        }

       // An Example
       // private void Update()
       // {
       //     if(Input.GetKeyDown(KeyCode.C))
       //     {
       //         SoundPlay("Sound");
       //     }
       // }


    }
}


