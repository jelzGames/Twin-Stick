using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUMEN_KEY = "master_volumen";
    const string DIFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level unlocked_";
    const string USER_PREFS = "user prefs";

    public static void SetMasterVolumen(float volumen)
    {
        if (volumen >= 0f && volumen <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUMEN_KEY, volumen);
        }
        else
        {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolumen()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUMEN_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // 0 or 1 true or false
        }
        else
        {
            Debug.LogError("Trying to load level");
        }
    }

    public static bool IsLevelUnlock(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to query level");
        }

        return false;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFICULTY_KEY);
    }

    public static void SetUserPrefs()
    {
        PlayerPrefs.SetInt(USER_PREFS, 1);
    }

    public static float GetUserPrefs()
    {
        return PlayerPrefs.GetInt(USER_PREFS);
    }
}
