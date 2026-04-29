using Sirenix.OdinInspector;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIGameManager : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public WindowManager wmanager = new ();

    private void Awake()
    {
        inputs = new();
    }


    private void OnEnable()
    {
        inputs.Enable();
        inputs.UI.Escape.performed += HideCurrentPanel;

        wmanager.OnElementAdded += OnElementAdded;
        wmanager.OnElementRemoved += OnElementRemoved;
    }


    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnElementAdded(Window window)
    {
       // window.window.SetAc ;
        //->leo el contenido , lo activo y lo pongo al frente
    }
    private void OnElementRemoved(Window window)
    {
        //->desactivo el panel y lo mando al final
    }

    private void HideCurrentPanel(InputAction.CallbackContext context)
    {
        //->pop wmanager.pop()?
        //-> verifico si la window de este pop esta activada o desactvida
        //-> si esta activa funciono normalmente
        //-> si ya esta desactivada hago una llamada recursiva haciendo pop hasta que encuentro uno que pueda desactivar
        Debug.Log("Escape");
    }

    public void BtnOpenPanel(GameObject panel)
    {
        Window window = new(panel);
        wmanager.Push(window);
    }
    [Button]
    public void PeekFromStack()
    {
        Debug.Log(wmanager.Peek().window.name);
    }
    [Button]
    public void Count() => Debug.Log(wmanager.Count);

}
