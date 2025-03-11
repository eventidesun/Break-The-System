using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;
    [SerializeField] public bool isLocked;
    [SerializeField] public int keyIndex;

    public static bool[] allKeys = new bool[1];

    public BoxCollider2D Collider2D;

    public void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKey(KeyCode.E) && !isLocked) {
            SceneManager.LoadScene(SceneName);
        }
    }

    public void Start() {
        allKeys = new bool[1];
    }

    public void Update() {
        if (allKeys[keyIndex]) {
            isLocked = false;
        }
    }

    public void Save() {
        PlayerPrefs.SetInt("SceneSaved", SceneManager.GetActiveScene().buildIndex);
    }

    public void Load() {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSaved"));
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScreen().buildIndex);
    }
}
