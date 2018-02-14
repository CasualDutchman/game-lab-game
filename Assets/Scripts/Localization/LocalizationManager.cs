using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour {

    public static LocalizationManager instance;

    string missingKeyString = "Missing Localized Info";
    public string languageIdName = "EN_us";

    Dictionary<string, string> localizedText;

    bool isReady = false;

    void Awake() {
        if (instance == null) {
            instance = this;
        }else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

	void Start () {
        OnLoadLocalizationFile(languageIdName);

        print(GetLocalizedValue("hello"));
        print(GetLocalizedValue("hello2"));
        print(GetLocalizedValue("hello3"));
    }
	
	void OnLoadLocalizationFile(string languageCode) {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, languageCode + ".txt");

        if (File.Exists(filePath)) {
            string[] dataArray = File.ReadAllLines(filePath);
            foreach (string data in dataArray) {
                if (data.StartsWith("/") || string.IsNullOrEmpty(data))
                    continue;

                string[] keyValue = data.Split('=');
                localizedText.Add(keyValue[0], keyValue[1]);
            }

            Debug.Log("Localized content loaded. Dictionary contains " + localizedText.Count + " entries");
        }
        else {
            Debug.LogError(languageCode + ".txt does not excist in the StreamingAssets folder.");
        }

        isReady = true;
    }

    public string GetLocalizedValue(string key) {
        string result = missingKeyString + ": key = " + key;
        if (localizedText.ContainsKey(key)) {
            result = localizedText[key];
        }

        return result;
    }

    public bool IsReady() {
        return isReady;
    }
}
