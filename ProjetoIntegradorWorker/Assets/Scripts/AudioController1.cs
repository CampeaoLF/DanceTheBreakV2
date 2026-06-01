using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController1 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        //int IndexDaMusicaDeFundo = Random.Range (0, 2);
        AudioClip musicaDeFundoDessaFase = clip[0];
        audioSource.clip = musicaDeFundoDessaFase;
        audioSource.Play();
    }

    void Update()
    {
        
    }
}
