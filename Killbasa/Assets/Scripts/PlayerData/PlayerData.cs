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
    [SerializeField] private float _lbLean;
    [SerializeField] private float _lbRich;
    [SerializeField] private int _boiledKielbasa;
    [SerializeField] private int _grilledKielbasa;
    [SerializeField] private int _smokedKielbasa;
    [SerializeField] private int _dryAgedKielbasa;

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
    
    public float LBLean
    {
        get { return _lbLean; }
        set { _lbLean = value; }
    }
    
    public float LBRich
    {
        get { return _lbRich; }
        set { _lbRich = value; }
    }
    
    public int BoiledKielbasa
    {
        get { return _boiledKielbasa; }
        set { _boiledKielbasa = value; }
    }
    
    public int GrilledKielbasa
    {
        get { return _grilledKielbasa; }
        set { _grilledKielbasa = value; }
    }
    
    public int SmokedKielbasa
    {
        get { return _smokedKielbasa; }
        set { _smokedKielbasa = value; }
    }
    
    public int DryAgedKielbasa
    {
        get { return _dryAgedKielbasa; }
        set { _dryAgedKielbasa = value; }
    }
}
