using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Interactable _interactable;
    private DialogoManager _dialogoManager;

    private Animator _animator;

    private float _speed = 2.0f;

    private bool up;
    private bool down;
    private bool right;
    private bool left;
    private bool isMoving;

    private bool isInDialogue = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _dialogoManager = FindObjectOfType<DialogoManager>();
    }

    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        up = moveVertical == 1;
        down = moveVertical == -1;
        right = moveHorizontal == 1;
        left = moveHorizontal == -1;

        isMoving = up || down || right || left;

        // so pode se mover se nao estiver falando com alguem
        if (!isInDialogue)
        {
            _animator.SetBool("runningLeft", left);
            _animator.SetBool("runningRight", right);
            _animator.SetBool("runningUp", up);
            _animator.SetBool("runningDown", down);
            _animator.SetBool("isMoving", isMoving);

            if (up)
            {
                transform.position += Vector3.up * _speed * Time.deltaTime;
            }
            else
            {
                if (down)
                {
                    transform.position += Vector3.down * _speed * Time.deltaTime;
                }
                else
                {
                    if (left)
                    {
                        transform.position += Vector3.left * _speed * Time.deltaTime;
                    }
                    else
                    {
                        if (right)
                        {
                            transform.position += Vector3.right * _speed * Time.deltaTime;
                        }
                    }
                }
            }
        }

        if (Input.GetButtonDown("Fire1") && _interactable != null)
        {
            if (!_dialogoManager.TemDialogo)
                isInDialogue = false;
            else
                isInDialogue = true;

            _dialogoManager.SeguirDialogo();
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        _interactable = collider2D.GetComponent<Interactable>();

        if (_interactable != null)
        {
            if (collider2D.gameObject.tag == "FirstDialogue")
                isInDialogue = true;

            _dialogoManager.CurrentInteractable = _interactable;
            _dialogoManager.MostrarNomeDescricao();
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        _interactable = null;
        _dialogoManager.FinalizarDialogo();
        isInDialogue = false;

        if (collider2D.gameObject.tag == "FirstDialogue")
            Destroy(collider2D.gameObject);
    }
}
