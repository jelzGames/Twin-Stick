using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private float fixedDeltaTime;
    private bool isPused = false;

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsLevelUnlock(1));
        print(PlayerPrefsManager.IsLevelUnlock(2));
        fixedDeltaTime = Time.fixedDeltaTime;

    }

    // Update is called once per frame
    void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && !isPused)
        {
            isPused = true;
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPused)
        {
            isPused = false;
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()  {
        Time.timeScale = 1;
        //project setting->time default value
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    private void OnApplicationPause(bool pause)
    {
        isPused = pause;
    }
}
