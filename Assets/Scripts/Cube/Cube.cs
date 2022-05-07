using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _valueText;
    [SerializeField] private Color[] _color;

    private int _value;
    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public int Value => _value;
    public bool MainCube = true;

    private void Start() 
    {
        int randomValue = GetRandomValue();
        SetValue(randomValue); 
        SetColor(randomValue);
    }

    private int GetRandomValue()
    {
        return (int)Mathf.Pow(2, Random.Range(1, 6));
    }

    private Color GetColor(int value)
    {
        return _color[(int)(Mathf.Log(value) / Mathf.Log(2)) - 1];
    }

    public void SetValue(int value)
    {
        for (int i = 0; i < _valueText.Length; i++)
        {
            _value = value;
            _valueText[i].text = _value.ToString();
        }
    }

    public void SetColor(int value)
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = GetColor(value);
    }

    public void HitImpulse()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(0,3,0, ForceMode.Impulse);
    }
}
