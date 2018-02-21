using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public bool isTownHall = false;

	void Start () {
		
	}
	
	public void OnBuildingClick() {
        if (isTownHall) {
            OnTownHall();
        }
    }

    void OnTownHall() {
        ScreenManager.instance.ChangeScreen("council");
    }
}
