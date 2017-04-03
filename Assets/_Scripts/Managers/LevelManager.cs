using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager _instance;
    private string _currentScene;
	// Use this for initialization
    protected void Start() {
        if (_instance != null && _instance != this) {
            Destroy (gameObject);
        } else {
            _instance = this;
            _currentScene = SceneManager.GetActiveScene().name;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadLevel(string name) {
        _currentScene = name;
        Application.LoadLevel (_currentScene);

    }

    public void QuitRequest(){
        Application.Quit ();
    }

    public string CurrentScene() {
        return _currentScene;
    }
}
