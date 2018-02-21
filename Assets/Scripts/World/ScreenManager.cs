using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

    public static ScreenManager instance;

    string currentScreen;
    string tobeScreen;

    public UIScreen[] screens;

    Transform currentScreenObject, tobeScreenObject;

    Dictionary<string, GameObject> screenDictionary = new Dictionary<string, GameObject>();

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        foreach (UIScreen uiscreen in screens) {
            screenDictionary.Add(uiscreen.screenType, uiscreen.screenObject);
        }

        screens = new UIScreen[0];
	}
	
	public void ChangeScreen(string screenname) {
        StartCoroutine(ChangeScreenCoroutine(screenname));
    }

    IEnumerator ChangeScreenCoroutine(string screen) {
        tobeScreen = screen;
        float timer = 0;

        if (string.IsNullOrEmpty(screen)) {
            tobeScreenObject = null;
        } 
        else {
            tobeScreenObject = screenDictionary[screen].transform;
        }
        
        while (currentScreen != tobeScreen) {
            timer += Time.deltaTime;

            if (currentScreenObject != null) {
                currentScreenObject.gameObject.SetActive(false);
            }

            if (tobeScreenObject != null) {
                tobeScreenObject.gameObject.SetActive(true);
            }

            if (timer >= 0.1f) {
                currentScreen = tobeScreen;

                currentScreenObject = tobeScreenObject;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    [System.Serializable]
    public class UIScreen {
        public string screenType;
        public GameObject screenObject;
    }
}
