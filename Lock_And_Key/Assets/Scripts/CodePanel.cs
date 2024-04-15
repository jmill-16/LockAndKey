using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    // Start is called before the first frame update

    public Text codeText;
    public string codeTextValue = "";
    public GameHandler gameHandler;
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "5432") {
            gameHandler.canOpenDoor = true;
        }

        if (codeTextValue.Length >= 4) {
            codeTextValue = "";
        }
        
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
        Debug.Log(codeTextValue);
    }
}
