using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voss.Util
{
    [CreateAssetMenu(menuName="Audio/Sound Effect")]
    public class SoundEffect : ScriptableObject
    {
        public AudioClip[] clips;
        public Vector2 pitchVariation;
        public Vector2 volumeVariation;
        
        public void Play(AudioSource source)
        {
            source.clip = clips.Pick();
            source.pitch = Random.Range(pitchVariation.x, pitchVariation.y);
            source.volume = Random.Range(volumeVariation.x, volumeVariation.y);
            source.Play();
        }
    }    
}
