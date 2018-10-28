using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace MainMenu
{
    public class SettingsMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void SetVolume (float volume)
        {
            audioMixer.SetFloat("Volume", volume);
        }

        public void Mute() 
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
