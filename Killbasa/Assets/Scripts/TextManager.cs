using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    
    private static TextManager _instance;
    public static TextManager Instance { get { return _instance; } }

    #region Text Variables

    [SerializeField] private TextMeshProUGUI currentDay;
    [SerializeField] private TextMeshProUGUI moneyAmount;
    [SerializeField] private TextMeshProUGUI fattyMeatAmount;
    [SerializeField] private TextMeshProUGUI leanMeatAmount;
    [SerializeField] private TextMeshProUGUI richMeatAmount;
    [SerializeField] private TextMeshProUGUI boiledSausageAmount;
    [SerializeField] private TextMeshProUGUI grilledSausageAmount;
    [SerializeField] private TextMeshProUGUI smokedSausageAmount;
    [SerializeField] private TextMeshProUGUI dryAgedSausageAmount;

    #endregion


    // Start is called before the first frame update

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

    public void GoToNight()
    {
        ResourceManager.Instance._currentDay++;
        ResourceManager.Instance.UpdatePlayerData();
        SceneManager.LoadScene(1);
        ResourceManager.Instance.ApplyDailyMaintainenceCosts();
    } 
    
    
    public void GoToNextDay()
    {
        SceneManager.LoadScene(0);
        ResourceManager.Instance._currentDay++;
        //UpdateUI();
    }

    public void UpdateUI()
    {
        moneyAmount.text = "$" + ResourceManager.Instance._currentMoney;
        fattyMeatAmount.text = ResourceManager.Instance._LBFattyMeat + "LBs";
        leanMeatAmount.text = ResourceManager.Instance._LBLeanMeat + "LBs";
        richMeatAmount.text = ResourceManager.Instance._LBRichMeat + "LBs";
        boiledSausageAmount.text = ResourceManager.Instance._numBoiledKielbasa + "LBs";
        grilledSausageAmount.text = ResourceManager.Instance._numGrilledKielbasa+ "LBs";
        smokedSausageAmount.text = ResourceManager.Instance._numSmokedKielbasa + "LBs";
        dryAgedSausageAmount.text = ResourceManager.Instance._numDryAgedKielbasa + "LBs";
        currentDay.text = ResourceManager.Instance._currentDay.ToString();
    }
}
