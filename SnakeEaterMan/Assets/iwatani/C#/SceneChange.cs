using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private AudioClip clips;
    private AudioSource audioSource;

    //shrue_S
    private float go_scene_Time = 0.0f;
    private bool nextScene_G = false;
    bool botan = true;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            nextScene_G = true;

            if (botan == true)
            {
                audioSource.PlayOneShot(clips);
                botan = false;
            }
        }


        if (nextScene_G == true)
        {
            go_scene_Time += Time.deltaTime;
            if (go_scene_Time > 3.7f)
            {
                SceneManager.LoadScene("GamePlay");
                go_scene_Time = 0;
            }
        }
        if (nextScene_G == false)
        {
            go_scene_Time = 0;
        }
    }
}