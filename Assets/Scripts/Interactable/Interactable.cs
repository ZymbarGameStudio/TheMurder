using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private DialogoManager _dialogoManager;

    public string nome;
    public string descricao;

    public Dialogo dialogo;

    // Start is called before the first frame update
    void Start()
    {
        _dialogoManager = FindObjectOfType<DialogoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
