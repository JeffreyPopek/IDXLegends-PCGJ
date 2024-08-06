using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class SausageData : ScriptableObject
{
    [SerializeField] private int _fattyNeeded;
    [SerializeField] private float _leanNeeded;
    [SerializeField] private float _richNeeded;
    [SerializeField] private int _sellAmount;

    public int FattyNeeded
    {
        get { return _fattyNeeded; }
        set { _fattyNeeded = value; }
    }
    
    public float LeanNeeded
    {
        get { return _leanNeeded; }
        set { _leanNeeded = value; }
    }
    
    public float RichNeeded
    {
        get { return _richNeeded; }
        set { _richNeeded = value; }
    }
    
    public int SellAmount
    {
        get { return _sellAmount; }
        set { _sellAmount = value; }
    }
}
