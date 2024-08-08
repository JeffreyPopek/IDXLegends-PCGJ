using UnityEngine;

public class DayActionManager : MonoBehaviour
{
    public void MakeBoiledKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 100)
        {
            ResourceManager.Instance._LBFattyMeat -= 100;
            ResourceManager.Instance._numBoiledKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    
    public void MakeGrilledKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 40 && ResourceManager.Instance._LBLeanMeat >= 60)
        {
            ResourceManager.Instance._LBFattyMeat -= 40;
            ResourceManager.Instance._LBLeanMeat -= 60;
            ResourceManager.Instance._numGrilledKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    
    public void MakeSmokedKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 20 && ResourceManager.Instance._LBRichMeat >= 80)
        {
            ResourceManager.Instance._LBFattyMeat -= 20;
            ResourceManager.Instance._LBFattyMeat -= 80;
            ResourceManager.Instance._numSmokedKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    
    public void MakeDryAgedKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 20 && ResourceManager.Instance._LBLeanMeat >= 40 && ResourceManager.Instance._LBRichMeat >= 40)
        {
            ResourceManager.Instance._LBFattyMeat -= 20;
            ResourceManager.Instance._LBLeanMeat -= 40;
            ResourceManager.Instance._LBRichMeat -= 40;
            ResourceManager.Instance._numDryAgedKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }


    //Sell functions:
    public void SellBoiledKielbasa()
    {
        if (ResourceManager.Instance._numBoiledKielbasa > 0)
        {
            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance.UpdatePlayerData();
        }
    }

    public void SellGrilledKielbasa()
    {
        if (ResourceManager.Instance._numGrilledKielbasa > 0)
        {
            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    public void SellSmokedKielbasa()
    {
        if (ResourceManager.Instance._numSmokedKielbasa > 0)
        {
            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance.UpdatePlayerData();
        }
    }

    public void SellDryAgedKielbasa()
    {
        if (ResourceManager.Instance._numDryAgedKielbasa > 0)
        {
            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
}
