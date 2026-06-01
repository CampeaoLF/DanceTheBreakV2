
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;
    public AudioClip levelMusic;
    // Start is called before the first frame update
    void Start()
    {
        //int IndexDaMusicaDeFundo = Random.Range (0, 2);
        AudioClip musicaDeFundoDessaFase = levelMusic;
        audioSource.clip = musicaDeFundoDessaFase;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
