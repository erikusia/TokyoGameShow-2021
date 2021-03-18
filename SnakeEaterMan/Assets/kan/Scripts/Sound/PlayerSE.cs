using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{
    public enum PlaySoundFlag
    {
        Dash,
        Eat,
        GetItem,
        PlasDash,
        Paralysis,
        MiniMap,
        Thunder,
        Debuff,
        ColorShuffle,
        OneColor,
        Stamina,

        None,
    }
    private PlaySoundFlag soundState;
    public PlaySoundFlag PlayerSoundState
    {
        set { soundState = value; }
        get { return soundState; }
    }
    //食べる
    [SerializeField]
    private AudioClip eatSE;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySE();
    }

    void PlaySE()
    {
        switch(soundState)
        {
            case PlaySoundFlag.Eat:
                audioSource.PlayOneShot(eatSE);
                break;
        }

        soundState = PlaySoundFlag.None;
    }
}
