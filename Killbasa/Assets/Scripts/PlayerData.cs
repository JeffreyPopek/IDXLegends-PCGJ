using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int _day;
    [SerializeField] private float _money;
    [SerializeField] private float _lbFatty;
    [SerializeField] private int _sausages;

    public int Day
    {
        get { return _day; }
        set { _day = value; }
    }
    
    public float Money
    {
        get { return _money; }
        set { _money = value; }
    }
    
    public float LBFatty
    {
        get { return _lbFatty; }
        set { _lbFatty = value; }
    }
    
    public int Sausages
    {
        get { return _sausages; }
        set { _sausages = value; }
    }
}
