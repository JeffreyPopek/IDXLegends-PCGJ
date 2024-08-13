using UnityEngine;

public class DayActionManager : MonoBehaviour
{
    public AudioSource makeSFX;
    public AudioSource sellSFX;

    public GameObject moneyParticle;
    public Camera cam;

    public void MakeBoiledKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 100)
        {
            makeSFX.Play();

            ResourceManager.Instance._LBFattyMeat -= 100;
            ResourceManager.Instance._numBoiledKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    
    public void MakeGrilledKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 40 && ResourceManager.Instance._LBLeanMeat >= 60)
        {
            makeSFX.Play();

            ResourceManager.Instance._LBFattyMeat -= 40;
            ResourceManager.Instance._LBLeanMeat -= 60;
            ResourceManager.Instance._numGrilledKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    
    public void MakeSmokedKielbasa()
    {
        if (ResourceManager.Instance._LBLeanMeat >= 20 && ResourceManager.Instance._LBRichMeat >= 80)
        {
            makeSFX.Play();

            ResourceManager.Instance._LBLeanMeat -= 20;
            ResourceManager.Instance._LBRichMeat -= 80;
            ResourceManager.Instance._numSmokedKielbasa++;
            
            ResourceManager.Instance.UpdatePlayerData();
        }
    }
    
    public void MakeDryAgedKielbasa()
    {
        if (ResourceManager.Instance._LBFattyMeat >= 20 && ResourceManager.Instance._LBLeanMeat >= 40 && ResourceManager.Instance._LBRichMeat >= 40)
        {
            makeSFX.Play();

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
            sellSFX.Play();

            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance._numBoiledKielbasa--;
            ResourceManager.Instance.UpdatePlayerData();

            SpawnMoneyParticle();
        }
    }

    public void SellGrilledKielbasa()
    {
        if (ResourceManager.Instance._numGrilledKielbasa > 0)
        {
            sellSFX.Play();

            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance._numGrilledKielbasa--;
            ResourceManager.Instance.UpdatePlayerData();

            SpawnMoneyParticle();
        }
    }
    public void SellSmokedKielbasa()
    {
        if (ResourceManager.Instance._numSmokedKielbasa > 0)
        {
            sellSFX.Play();

            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance._numSmokedKielbasa--;
            ResourceManager.Instance.UpdatePlayerData();

            SpawnMoneyParticle();
        }
    }

    public void SellDryAgedKielbasa()
    {
        if (ResourceManager.Instance._numDryAgedKielbasa > 0)
        {
            sellSFX.Play();

            ResourceManager.Instance._currentMoney += 200;
            ResourceManager.Instance._numDryAgedKielbasa--;
            ResourceManager.Instance.UpdatePlayerData();

            SpawnMoneyParticle();
        }
    }

    private void SpawnMoneyParticle()
    {
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnPos.y += 0.5f;
        spawnPos.z = 0;

        Instantiate(moneyParticle, spawnPos, Quaternion.identity);
    }
}
