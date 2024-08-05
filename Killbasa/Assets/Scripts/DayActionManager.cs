using UnityEngine;

public class DayActionManager : MonoBehaviour
{
    public void MakeSausage()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 10)
        {
            ResourceManager.Instance._LBFattyMeat -= 10;
            ResourceManager.Instance._currentSausage++;
            
            TextManager.Instance.UpdateUI();
        }
    }
    
    public void SellSausage()
    {
        //Debug.Log(ResourceManager.Instance._currentSausage);
        if (ResourceManager.Instance._currentSausage >= 1)
        {
            ResourceManager.Instance._currentSausage--;
            ResourceManager.Instance._currentMoney++;
            
            TextManager.Instance.UpdateUI();
        }
    }
    
    
}
