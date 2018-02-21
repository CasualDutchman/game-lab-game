using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Infinity;

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 50, LayerMask.GetMask("Building"));

            if (hit.collider != null) {
                if (hit.collider.GetComponent<Building>()) {
                    hit.collider.GetComponent<Building>().OnBuildingClick();
                }
            }

        }
	}
}
