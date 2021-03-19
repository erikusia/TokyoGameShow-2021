using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{

        //Dash,
        //Eating,
        //GetItem,
        //DashItem,
        //Paralysis,
        //MiniMap,
        //Thunder,
        //Debuff,
        //ColorShuffle,
        //OneColor,
        //Stamina,
        //None,

    private string soundName;
    public string PlayerSoundName
    {
        set { soundName = value; }
        get { return soundName; }
    }

    [SerializeField]
    private AudioClip[] SE;
    private Dictionary<string, AudioClip> SEList;
    private AudioSource audioSource;

    void Start()
    {
        soundName = "None";
        audioSource = GetComponent<AudioSource>();
        SEList = new Dictionary<string, AudioClip>();
        for(int i = 0;i < SE.Length;++i)
        {
            SEList.Add(SE[i].name, SE[i]);
        }
    }

    void Update()
    {
        PlaySE();
    }

    void PlaySE()
    {

        if(soundName != "None")
            audioSource.PlayOneShot(SEList[soundName]);

        soundName = "None";
    }
}
