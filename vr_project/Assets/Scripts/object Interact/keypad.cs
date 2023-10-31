using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using System.Linq;

public class keypad : MonoBehaviour
{

    private List<int>enteredPassword = new List<int>();
    private List<int> correctPassword = new List<int>() { 1, 1, 0, 1 };

    [SerializeField]private TextMeshProUGUI EnteredCode;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerEntered(int enterKey)
    {
        if(enteredPassword.Count >= 4)
        {
            checkPassword();
        }

        Debug.Log("keypad press");
        enteredPassword.Add(enterKey);
        DisplayEntered();
    }

    private void checkPassword()
    {
        bool isEqual = Enumerable.SequenceEqual(enteredPassword, correctPassword);
        if (isEqual)
        {
            Debug.Log("password correct");
        }
        else
        {
            Debug.Log("wrong password");
            enteredPassword.Clear();
        }
    }

    private void DisplayEntered()
    {
        EnteredCode.text = null;

        for(int i = 0; i < enteredPassword.Count; i++)
        {
            EnteredCode.text += enteredPassword[i];
        }
    }
}
