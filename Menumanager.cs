using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menumanager : MonoBehaviour {
    private string Escena = "Escena1";
    public Button boton, boton1, boton2;
    public GameObject aux;
    private bool activo;
    void Awake()
    {
       
        aux = GameObject.Find("Menudeescena");
        activo = false;

    }
    void Start () {
        aux.SetActive(false);
	}
	
	
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
         {
            aux.SetActive(true);
            boton.onClick.AddListener(() => Reiniciar(false));
        }
    }

    private void Reiniciar(bool seguro)
    {
        if (seguro)
        {
            SceneManager.LoadScene(Escena, LoadSceneMode.Single);
        }
        else
        {
            activo = true;
        }
       
    }
    void OnGUI()
    {
        string mensaje = "¿Estas seguro...?";
        if(activo)
        {
            //poner bonito in a future;
            GUI.skin.label.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(Screen.width / 2 - 300, 50, 500, 50), mensaje);
            using (var areaScope = new GUILayout.AreaScope(new Rect(Screen.width / 2 - 300, 100, 500, 50)))
            {

                
                if (GUILayout.Button("Si"))
                {
                    Reiniciar(true);
                }
                if (GUILayout.Button("No"))
                {
                    activo = false;
                }
            }
        }
    }

}
