using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class SCR_Login : MonoBehaviour {

    public SCR_MainMenu mainMenuManager;
    public Text txtError;
    [Tooltip("Input field donde el usuario su nombre de usuario")]
    public InputField userField;
    [Tooltip("Input field donde el usuario pondra su contrasenia")]
    public InputField passwordField;
    [Tooltip("Boton que enviara el login")]
    public Button btnSubmit;

    private void Start()
    {
        ClearFields();
        SelectUserField();
    }

    public void ClearFields()
    {
        txtError.text = "";
    }

    public void SelectUserField()
    {
        userField.Select();
    }

    public void SelectPasswordField()
    {
        passwordField.Select();
    }

    public void SelectSubmit()
    {
        btnSubmit.Select();
    }

    public void OnSubmitClicked()
    {
        //hash password
        if(string.IsNullOrEmpty(userField.text))
        {
            txtError.text = "Ingresa tu usuario";
            return;
        }

        if(string.IsNullOrEmpty(passwordField.text))
        {
            txtError.text = "Ingresa tu contraseña";
            return;
        }

        string passwordHashed = SCR_CreateUser.HashPassword(passwordField.text);

        StartCoroutine(Login(userField.text, passwordHashed));
    }

    IEnumerator Login(string _user, string _passwordHash)
    {
        WWWForm form = new WWWForm();
        form.AddField("_username", _user);
        form.AddField("_passwordHash", _passwordHash);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(ServerInfo.host + "Unity_Login.php", form))
        {
            yield return webRequest.SendWebRequest();


            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.Log("Error");
                txtError.text = "Error en la conexión. Asegúrese de estar conectado a internet.";
            }
            else if (string.IsNullOrEmpty(webRequest.downloadHandler.text))
            {
                Debug.Log("Didn't get what i wanted");
                txtError.text = "Hubo un error, intente de nuevo.";
            }
            else
            {
                int result = 5;
                int.TryParse(webRequest.downloadHandler.text, out result);
                if (result == 0)
                {
                    txtError.text = "El usuario y la contraseña no coinciden.";
                }
                else if (result == 1)
                {
                    SCR_LoadUserData.currentUsername = userField.text;
                    mainMenuManager.OpenLevelSelection();
                }
            }
        }

    }

}
