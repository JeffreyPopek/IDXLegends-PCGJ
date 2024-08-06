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
}
