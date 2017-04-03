using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    private LevelManager _levelManager;

    protected void Start() {
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void OnPlay() {
        _levelManager.LoadLevel("Level1");
    }

    public void OnQuit() {
        _levelManager.QuitRequest();
    }
}
