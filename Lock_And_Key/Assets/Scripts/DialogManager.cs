using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueScript : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;

    //public static DialogManager Instance { get; private set; }

    // private void Awake() {
    //     Instance = this;
    // }

    
    public void ShowDialog(Dialog dialog) {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line) {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
