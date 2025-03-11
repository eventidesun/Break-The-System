using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{

    [SerializeField] public int keyIndex;

    public BoxCollider2D collider;
    public SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerStay2D(Collider2D other) {
        SceneLoader.allKeys[keyIndex] = true;

        Destroy(collider);
        Destroy(spriteRenderer);
    }
}
