using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderAuto : MonoBehaviour
{
    public string SceneName;

    public BoxCollider2D Collider2D;

    public void OnTriggerStay2D(Collider2D other) {
        SceneManager.LoadScene(SceneName);
    }
}
