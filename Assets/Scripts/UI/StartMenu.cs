using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(1000)]
public class StartMenu : MonoBehaviour
{
    public TMP_InputField inputField;
   
    
    // Start is called before the first frame update
    public void StartButton()
    {
        PersistenceManager.Instance.currentPlayer = inputField.text;
        SceneManager.LoadScene("main");
    }

}
