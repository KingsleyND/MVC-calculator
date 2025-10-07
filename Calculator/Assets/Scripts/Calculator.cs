using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows;

public class Calculator : MonoBehaviour
{
    [SerializeField]
    Text InputField;

    //MODEL
    //Arithmetic Functions
    public float add(float a, float b) {  return a + b; }
    public float subtract(float a, float b) { return a - b; }
    public float multiply(float a, float b) { return a * b; }
    public float divide(float a, float b) {  return a / b; }

  
    //Initial values
    public string digitA = "";
    public string digitB = "";
    public float result = 0;        
    public string operatorFn = "";
    public bool saveA = false;

    
    public void clearInput()
    {
        digitA = "";
        digitB = "";
        result = 0;
        operatorFn = "";
        saveA = false;
     }
    //This function clears input values while keeping result as 1st value on operation
    public void clearInputSaveA()
    {
        digitA = result.ToString();
        digitB = "";
        result = 0;
        operatorFn = "";
        saveA = false;
    }
    //VIEW  
    public void clearScreen() { InputField.text = ""; }

    string[] symbols = new string[] { "+","-","/","*"};

    //CONTROLLER
    public void ButtonPressed()
    {

        string buttonValue = EventSystem.current.currentSelectedGameObject.name;

        int arg;
        if (saveA == false)
        {
            if (int.TryParse(buttonValue, out arg) || buttonValue == ".")
            {
             
                digitA += buttonValue;
                InputField.text = digitA;
                
            }
            else if (symbols.Contains(buttonValue))
            {
                InputField.text = "";
                saveA = true;
                operatorFn = buttonValue;
            }
        }
        
        else if (int.TryParse(buttonValue, out arg) || buttonValue == ".")
        {
            if (saveA == true)
            {
                digitB += buttonValue;
                InputField.text = digitB;
            }
            
        }
        if (buttonValue == "=")
        {
            //Clears screen and displays result according to switchcase
            clearScreen();
            switch(operatorFn)
            {
                case "+":
                    result = add(float.Parse(digitA), float.Parse(digitB));

                    InputField.text = result.ToString(); break;


                case "-":
                    result = subtract(float.Parse(digitA),float.Parse(digitB));
                    InputField.text = result.ToString();break;
                case "*":
                    result = multiply(float.Parse(digitA), float.Parse(digitB));
                    InputField.text = result.ToString();break;
                case "/":
                    result = divide(float.Parse(digitA), int.Parse(digitB));
                    InputField.text = result.ToString();break;
            }
            clearInputSaveA();

        }else if(buttonValue == "C") {
            clearInput();
            InputField.text = "0";
        }
        
        

    }
}
