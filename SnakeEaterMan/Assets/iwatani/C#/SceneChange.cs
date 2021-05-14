using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //[SerializeField]
    //private AudioClip clips;
    private AudioSource audioSource;

    //shrue_S
    private float go_scene_Time = 0.0f;
    private bool nextScene_G = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Input.anyKeyDown)
        {
          //  audioSource.PlayOneShot(clips);
            nextScene_G = true;
        }
      if (nextScene_G == true)
        {
            go_scene_Time += Time.deltaTime;
            if (go_scene_Time > 5)
            {
                SceneManager.LoadScene("GamePlay");
                go_scene_Time = 0;
            }
        }
        if(nextScene_G ==false)
        {
            go_scene_Time = 0;
        }
    }
}
//if (Input.anyKeyDown)
//{
//    SceneManager.LoadScene("GamePlay");
//}