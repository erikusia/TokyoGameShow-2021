using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;

	[SerializeField]
	private AudioClip clips;
	private AudioSource audioSource;

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 11"))
		{
			if (pauseUIInstance == null)
			{
				audioSource.PlayOneShot(clips);
				pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
				Time.timeScale = 0f;
			}
			else
			{
				audioSource.PlayOneShot(clips);
				Destroy(pauseUIInstance);
				Time.timeScale = 1f;
			}
		}

		if (Mathf.Approximately(Time.timeScale, 0f))
		{
			return;
		}
	}
}
