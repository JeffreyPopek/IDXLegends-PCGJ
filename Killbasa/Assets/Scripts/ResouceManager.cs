using System;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;

    public static ResourceManager Instance { get { return _instance; } }

    #region Player Resources

    [SerializeField] private PlayerData _playerData;
    
    public int _currentDay;
    public float _currentMoney;
    
    // Meats
    public float _LBFattyMeat;
    public int _currentSausage;

    #endregion
    

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            _instance = this;
        }
    }

    private void Start()
    {
        SetPlayerData();
        TextManager.Instance.UpdateUI();
    }

    private void SetPlayerData()
    {
        // Get data from PlayerData scriptable object
        _currentDay = _playerData.Day;
        _currentMoney = _playerData.Money;
        _LBFattyMeat = _playerData.LBFatty;
        _currentSausage = _playerData.Sausages;
    }

    public void UpdatePlayerData()
    {
        // Set data in PlayerData scriptable object
        _playerData.Day = _currentDay;
        _playerData.Money = _currentMoney;
        _playerData.LBFatty = _LBFattyMeat;
        _playerData.Sausages = _currentSausage;
    }
}
