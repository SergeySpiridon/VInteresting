using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject _shield;
    private Renderer _renderer;
    private Collider2D _collider;
    public float Health { get; private set; }
    void Start()
    {
        Health = 1f;
        _renderer = gameObject.GetComponent<Renderer>();
        _collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            ShieldActive();
    }
    private void ShieldActive()
    {
        if (!Input.GetKey(KeyCode.UpArrow))
        {
         
            //   _shield = gameObject.transform.GetChild(0).GetComponentInChildren<GameObject>();

            _renderer.enabled = false;
            _collider.enabled = false;
            return;
        }
        else
        {
            Debug.Log("33");
            _renderer.enabled = true;
            _collider.enabled = true;
        }
    }
}
