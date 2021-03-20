using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }
    public void OnClick()
    {
        audioSource.PlayOneShot(clip);
        SceneManager.LoadScene("Title");
        //Debug.Log("title");
    }
}
