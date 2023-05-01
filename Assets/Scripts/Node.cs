using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;

    private Renderer _rend;
    private Color _startColor;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    private void OnMouseEnter()
    {
        _rend.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
