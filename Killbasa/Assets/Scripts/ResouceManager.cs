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
    public int _timesCaught;
    public float _suspicion;
    
    // Meats
    public float _LBFattyMeat;
    public float _LBLeanMeat;
    public float _LBRichMeat;

    public int _numBoiledKielbasa;
    public int _numGrilledKielbasa;
    public int _numSmokedKielbasa;
    public int _numDryAgedKielbasa;
    

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
        _timesCaught = _playerData.TimesCaught;
        _suspicion = _playerData.Suspicion;
        
        _LBFattyMeat = _playerData.LBFatty;
        _LBLeanMeat = _playerData.LBLean;
        _LBRichMeat = _playerData.LBRich;
        
        _numBoiledKielbasa = _playerData.BoiledKielbasa;
        _numGrilledKielbasa = _playerData.GrilledKielbasa;
        _numSmokedKielbasa = _playerData.SmokedKielbasa;
        _numDryAgedKielbasa = _playerData.DryAgedKielbasa;
    }

    public void UpdatePlayerData()
    {
        // Set data in PlayerData scriptable object
        _playerData.Day = _currentDay;
        _playerData.Money = _currentMoney;
        _playerData.TimesCaught = _timesCaught;
        _playerData.Suspicion = _suspicion;

        
        _playerData.LBFatty = _LBFattyMeat;
        _playerData.LBLean = _LBLeanMeat;
        _playerData.LBRich = _LBRichMeat;
        
        _playerData.BoiledKielbasa = _numBoiledKielbasa;
        _playerData.GrilledKielbasa = _numGrilledKielbasa;
        _playerData.SmokedKielbasa = _numSmokedKielbasa;
        _playerData.DryAgedKielbasa = _numDryAgedKielbasa;
        
        if (TextManager.Instance)
            TextManager.Instance.UpdateUI();
    }

    public void ResetPlayerData()
    {
        _currentDay = 0;
        _currentMoney = 0;
        _timesCaught = 0;
        _suspicion = 0;

        _LBFattyMeat = 0;
        _LBLeanMeat = 0;
        _LBRichMeat = 0;

        _numBoiledKielbasa = 0;
        _numGrilledKielbasa = 0;
        _numSmokedKielbasa = 0;
        _numDryAgedKielbasa = 0;

        UpdatePlayerData();
    }

    public void ApplyDailyMaintainenceCosts()
    {
        _playerData.Money = _currentMoney - 100;
    }
}
