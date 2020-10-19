using UnityEngine;

public class UI_TextMessage : MonoBehaviour {
    public float existTime;


    private void Start() {
        Destroy(gameObject, existTime);
    }
}
