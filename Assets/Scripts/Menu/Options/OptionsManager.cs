using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    public static OptionsManager instance;

    //Audio
    float musicLevel = 1;
    float effectsLevel = 1;

    //Graphical


    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        OnOptionsLoad();
    }
	
    void OnOptionsLoad() {

    }

    void OnOptionsSave() {

    }
}
