using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
    public Image nameBorder;
    public Image dialogoBorder;
    public Image nameBackground;
    public Image dialogoBackground;

    public Text nameText;
    public Text dialogoText;

    public Text dicaText;

    public bool TemDialogo { get { return _frases.Count != 0; }  }

    public Interactable CurrentInteractable { get; set; }
    private Queue<string> _frases;
    
    public void Start()
    {
        _frases = new Queue<string>();
    }

    public void MostrarNomeDescricao()
    {
        nameBorder.gameObject.SetActive(true);
        dialogoBorder.gameObject.SetActive(true);
        nameBackground.gameObject.SetActive(true);
        dialogoBackground.gameObject.SetActive(true);

        nameText.text = CurrentInteractable.nome;

        foreach (var frase in CurrentInteractable.dialogo.frases)
        {
            _frases.Enqueue(frase);
        }

        StopAllCoroutines();
        StartCoroutine(EscreverDialogo(CurrentInteractable.descricao));
    }

    public IEnumerator EscreverDialogo(string dialogo)
    {
        dialogoText.text = "";
        dicaText.text = "";

        foreach (var c in dialogo.ToCharArray())
        {
            dialogoText.text += c;
            yield return null;
        }

        StopAllCoroutines();
        StartCoroutine(EscreverDica("Clique no mouse para continuar"));
    }

    public IEnumerator EscreverDica(string dica)
    {
        dicaText.text = "";

        foreach (var c in dica.ToCharArray())
        {
            dicaText.text += c;
            yield return null;
        }
    }

    public void SeguirDialogo()
    {
        if(_frases.Count == 0)
        {
            FinalizarDialogo();
            return;
        }

        var frase = _frases.Dequeue();

        StopAllCoroutines();
        StartCoroutine(EscreverDialogo(frase));
    }

    public void FinalizarDialogo()
    {
        StopAllCoroutines();

        nameText.text = "";
        dialogoText.text = "";
        dicaText.text = "";

        nameBorder.gameObject.SetActive(false);
        dialogoBorder.gameObject.SetActive(false);
        nameBackground.gameObject.SetActive(false);
        dialogoBackground.gameObject.SetActive(false);
    }
}
