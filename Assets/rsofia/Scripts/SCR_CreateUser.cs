using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using System;

public class SCR_CreateUser : MonoBehaviour {

    public SCR_MainMenu mainMenuManager;
    [Tooltip("Input field donde el usuario pondra el nombre de su usuario")]
    public InputField userField;
    [Tooltip("Input field donde el usuario pondra su correo electronico")]
    public InputField emailField;
    [Tooltip("Toggle que nos permitira saber si el usuario es sordo o no")]
    public Toggle isDeaf;
    [Tooltip("Numero de avatar que usara")]
    public SCR_Avatars avatar;
    [Tooltip("Input field donde el usuario pondra su contrasenia para crearla")]
    public InputField passwordField;
    [Tooltip("Input field donde se escribira la misma contrasenia pero repetida, para ver si son iguales")]
    public InputField confirmPasswordField;
    [Tooltip("Arreglo de imagenes que sirven para mostrar la fuerza de la contrasenia")]
    public Image[] securityShowoff;
    [Tooltip("Texto donde se mostrara si las contrasenias coinciden")]
    public Text txtPasswordsMatch;
    [Tooltip("Imagen donde se mostrara si las contrasenias coinciden")]
    public GameObject imgPasswordsMatch;
    private bool doPasswordsMatch = false; //confirma si las contrasenias son iguales
    [Tooltip("Boton de confirmar para crear la contrasenia")]
    public Button btnSubmit;

    public Text txtDisplayErrors;
    

    private string mySalt = "ASGNE3C8~U2018C"; // NEVER CHANGE THIS. THIS WILL HELP MAKE THE HASH OF THE PASSWORDS

    //Para indicar que tan fuerte es la contrasenia
    private enum SECURITYSTATES
    {
        EMPTY,
        HAZARD,
        MEDIUM,
        SAFE
    }

    private void Start()
    {
        ClearFields();
    }

    public void ClearFields()
    {
        imgPasswordsMatch.SetActive(false);
        btnSubmit.interactable = false;
        passwordField.text = "";
        confirmPasswordField.text = "";
        txtDisplayErrors.text = "";
        userField.text = "";
        isDeaf.isOn = false;
        OnUpdatePassword();
    }

    //Se llama cada que el input field de la contrasenia es cambiado
    //De aqui se llana la funcion que actualiza la fuerza de la contrasenia
    public void OnUpdatePassword()
    {
        if (string.IsNullOrEmpty(passwordField.text))
        {
            UpdateSecurityShowoff(SECURITYSTATES.EMPTY);
        }
        else if (passwordField.text.Length <= 6)
        {
            UpdateSecurityShowoff(SECURITYSTATES.HAZARD);
        }
        else if ((passwordField.text.Length >= 6 && passwordField.text.Length < 8) || (ContainsSpecialCharacters() && passwordField.text.Length < 8))
        {
            UpdateSecurityShowoff(SECURITYSTATES.MEDIUM);
        }
        else if (passwordField.text.Length >= 8 && ContainsSpecialCharacters())
        {
            UpdateSecurityShowoff(SECURITYSTATES.SAFE);
        }

        OnCheckIfPasswordsMatch();
    }

    // Actualiza las imagenes que indican que tan fuerte es la contrasenia, donde rojo es muy poco, y verde es mucho
    private void UpdateSecurityShowoff(SECURITYSTATES state)
    {
        Color safetyColor = Color.white;
        int count = 0;
        switch (state)
        {
            case SECURITYSTATES.HAZARD:
                safetyColor = Color.red;
                count = 1;
                break;
            case SECURITYSTATES.MEDIUM:
                safetyColor = new Color(1, 1, 0, 1);
                count = 3;
                break;
            case SECURITYSTATES.SAFE:
                safetyColor = Color.green;
                count = 5;
                break;
        }
        for (int i = 0; i < securityShowoff.Length; i++)
        {
            if (i < count)
            {
                securityShowoff[i].color = safetyColor;
            }
            else
            {
                securityShowoff[i].color = Color.white;
            }

        }
    }

    //Checa si la contrasenia tiene caracteres a parte de letras
    private bool ContainsSpecialCharacters()
    {
        bool result = false;
        foreach (char c in passwordField.text)
        {
            if (!(c >= 65 && c <= 90) && !(c >= 97 && c <= 122))
            {
                Debug.Log("Contains Special Characters");
                result = true;
                break;
            }
        }

        return result;
    }

    //Funcion que compara si la contrasenia y la contrasenia confirmada son iguales
    public void OnCheckIfPasswordsMatch()
    {
        if (!string.IsNullOrEmpty(passwordField.text) && !string.IsNullOrEmpty(confirmPasswordField.text))
        {
            if (passwordField.text != confirmPasswordField.text)
            {
                doPasswordsMatch = false;
                txtPasswordsMatch.text = "LAS CONTRASEÑAS NO COINCIDEN";
                imgPasswordsMatch.SetActive(false);
                btnSubmit.interactable = false;
            }
            else
            {
                doPasswordsMatch = true;
                txtPasswordsMatch.text = "";
                imgPasswordsMatch.SetActive(true);
                //No habilidar el boton de submit hasta que coincidan
                btnSubmit.interactable = true;
            }
        }
    }

    //Funcion que selecciona el input field con el que se confirma la contrasenia
    public void SelectConfirmPassword()
    {
        confirmPasswordField.Select();
    }
    //Funcion que seleccina el input field con el que se termina la operacion
    public void SelectConfirmButton()
    {
        btnSubmit.Select();
    }

    public void Submit()
    {
        if(string.IsNullOrEmpty(userField.text))
        {
            txtDisplayErrors.text = "Ingresa tu usuario";
            return;
        }
        
        if (string.IsNullOrEmpty(emailField.text))
        {
            //Display Warning
            txtDisplayErrors.text = "Ingresa tu correo";
            return;
        }

        if (doPasswordsMatch)
        {
           

            byte[] bytes = Encoding.UTF8.GetBytes(mySalt + passwordField.text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string passwordHash = string.Empty;
            foreach (byte x in hash)
            {
                passwordHash += String.Format("{0:x2}", x);
            }
            Debug.Log("My Passwords: " + passwordField.text + " My Hash: " + passwordHash);

            StartCoroutine(SendPasswordHashToDB(passwordHash));
        }
        else
            txtDisplayErrors.text = "Las contraseñas deben coincidir";
    }

    #region SEND TO DATABASE//THIS IS STILL UNDER CONSTRUCTION
    IEnumerator SendPasswordHashToDB(string hash)
    {
        WWWForm form = new WWWForm();
        form.AddField("passwordHash", hash);

        WWW www = new WWW("http://google.com");
        yield return www;

        
        //Open Login
        mainMenuManager.OpenLogin();
    }
    #endregion
}
