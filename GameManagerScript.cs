using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    [Header("Upgrades")]
    [SerializeField] private GameObject upgradeBar;
    [SerializeField] private string[] powerups = { "Speed", "FireTime", "FireMode", "XPMultiplier" };
    [SerializeField] private string[] descriptions = { "Increased Movement Speed!", "Increased Fire Rate!", "Cross Fire Mode!", "Diagonal Fire Mode", "Mixed Fire Mode!", "Increased XP Multiplier!" };
    [SerializeField] private string[] headers = { "Increase Movement Speed", "Increase Fire Rate", "Add Cross Fire Mode", "Add Diagonal Fire Mode", "Add Mixed Fire Mode", "Increase XP Multiplier" };
    [SerializeField] private string[] rarities = { "common", "uncommon", "rare", "epic", "legendary" };
    [Header("Upgrade 1")]
    [SerializeField] private Text header1;
    [SerializeField] private Text rarity1;
    [SerializeField] private Text description1;
    [Header("Upgrade 2")]
    [SerializeField] private Text header2;
    [SerializeField] private Text rarity2;
    [SerializeField] private Text description2;
    [Header("Upgrade 3")]
    [SerializeField] private Text header3;
    [SerializeField] private Text rarity3;
    [SerializeField] private Text description3;
    [Header("UI")]
    [SerializeField] private GameObject UI;
    private void LevelUp()
    {
        PlayerPrefs.SetInt("canMove", 0);
        upgradeBar.SetActive(true);
        UI.SetActive(true);
        UpdateCard(header1, rarity1, description1);
        UpdateCard(header2, rarity2, description2);
        UpdateCard(header3, rarity3, description3);
    }
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("canMove", 1);
        PlayerPrefs.SetFloat("speed", 3);
        PlayerPrefs.SetFloat("FireRate", 0);
        PlayerPrefs.SetFloat("XPMultiplier", 1);
    }
    private void Awake()
    {
        ResetPlayerPrefs();
    }
    private void Start()
    {
        StartCoroutine("waitForLevelUp");
    }
    private IEnumerator waitForLevelUp()
    {
        yield return new WaitForEndOfFrame();
        if(PlayerPrefs.GetInt("isLeveling") == 1)
        {
            LevelUp();
        }
        else
        {
            StartCoroutine("waitForLevelUp");
        }
    }
    private void UpdateCard(Text header, Text rarity, Text description)
    {
        //Rarity Chooser
        int rarityChooser = Random.Range(1, 100);
        if (rarityChooser == 88)
        {
            rarity.text = rarities[4];
        }
        else if (rarityChooser <= 88 && rarityChooser >= 70)
        {
            rarity.text = rarities[3];
        }
        else if (rarityChooser < 70 && rarityChooser >= 40)
        {
            rarity.text = rarities[2];
        }
        else if (rarityChooser < 40 && rarityChooser >= 10)
        {
            rarity.text = rarities[1];
        }
        else
        {
            rarity.text = rarities[0];
        }

        //PowerUp Chooser
        int powerup = Random.Range(1, 4);

        if (powerup == 1) //Speed
        {
            header.text = headers[0];
            description.text = descriptions[0];
        }
        else if (powerup == 2) //Firerate
        {
            header.text = headers[1];
            description.text = descriptions[1];
        }
        else if (powerup == 3) //Firemode
        {
            header.text = headers[2];
            int powerupChooser = Random.Range(1, 2);
            if(rarity.text == rarities[4])
            {
                description.text = descriptions[4];
            }
            else if(powerupChooser == 1)
            {
                description.text = descriptions[2];
            }
            else if(powerupChooser == 2)
            {
                description.text = descriptions[3];
            }

        }
        else if (powerup == 4) //XP Multiplier
        {
            header.text = headers[3];
            description.text = descriptions[5];
        }
    }
    public void ChooseFirst()
    {
        int rarityINT = 1;
        if(rarity1.text == rarities[4])
        {
            rarityINT = 5;
        }
        else if (rarity1.text == rarities[3])
        {
            rarityINT = 4;
        }
        else if (rarity1.text == rarities[2])
        {
            rarityINT = 3;
        }
        else if (rarity1.text == rarities[1])
        {
            rarityINT = 2;
        }
        else if (rarity1.text == rarities[0])
        {
            rarityINT = 1;
        }

        if (description1.text == descriptions[0])
        {
            PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") + (0.05f * rarityINT));
        }
        else if(description1.text == descriptions[1])
        {
            PlayerPrefs.SetFloat("FireRate", PlayerPrefs.GetFloat("FireRate") + (0.03f * rarityINT));
        }
        else if (description1.text == descriptions[2])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(0);
            shooting.SetFireMode(1);
        }
        else if (description1.text == descriptions[3])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(2);
        }
        else if (description1.text == descriptions[4])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(3);
        }
        else if (description1.text == descriptions[5])
        {
            PlayerPrefs.SetFloat("XPMultiplier", PlayerPrefs.GetFloat("XPMultiplier") + (0.05f * rarityINT));
        }
        Close();
    }
    public void ChooseSecond()
    {
        int rarityINT = 1;
        if (rarity2.text == rarities[4])
        {
            rarityINT = 5;
        }
        else if (rarity2.text == rarities[3])
        {
            rarityINT = 4;
        }
        else if (rarity2.text == rarities[2])
        {
            rarityINT = 3;
        }
        else if (rarity2.text == rarities[1])
        {
            rarityINT = 2;
        }
        else if (rarity2.text == rarities[0])
        {
            rarityINT = 1;
        }

        if (description2.text == descriptions[0])
        {
            PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") + (0.05f * rarityINT));
        }
        else if (description2.text == descriptions[1])
        {
            PlayerPrefs.SetFloat("FireRate", PlayerPrefs.GetFloat("FireRate") + (0.03f * rarityINT));
        }
        else if (description2.text == descriptions[2])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(0);
            shooting.SetFireMode(1);
        }
        else if (description2.text == descriptions[3])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(2);
        }
        else if (description2.text == descriptions[4])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(3);
        }
        else if (description2.text == descriptions[5])
        {
            PlayerPrefs.SetFloat("XPMultiplier", PlayerPrefs.GetFloat("XPMultiplier") + (0.05f * rarityINT));
        }
        Close();
    }
    public void ChooseThird()
    {
        int rarityINT = 1;
        if (rarity3.text == rarities[4])
        {
            rarityINT = 5;
        }
        else if (rarity3.text == rarities[3])
        {
            rarityINT = 4;
        }
        else if (rarity3.text == rarities[2])
        {
            rarityINT = 3;
        }
        else if (rarity3.text == rarities[1])
        {
            rarityINT = 2;
        }
        else if (rarity3.text == rarities[0])
        {
            rarityINT = 1;
        }

        if (description3.text == descriptions[0])
        {
            PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") + (0.05f * rarityINT));
        }
        else if (description3.text == descriptions[1])
        {
            PlayerPrefs.SetFloat("FireRate", PlayerPrefs.GetFloat("FireRate") + (0.03f * rarityINT));
        }
        else if (description3.text == descriptions[2])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(0);
            shooting.SetFireMode(1);
        }
        else if (description3.text == descriptions[3])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(2);
        }
        else if (description3.text == descriptions[4])
        {
            var shooting = player.AddComponent<LineShootingPowerUp>();
            shooting.SetFireMode(3);
        }
        else if (description3.text == descriptions[5])
        {
            PlayerPrefs.SetFloat("XPMultiplier", PlayerPrefs.GetFloat("XPMultiplier") + (0.05f * rarityINT));
        }
        Close();
    }
    private void Close()
    {
        upgradeBar.SetActive(false);
        UI.SetActive(true);
        PlayerPrefs.SetInt("isLeveling", 0);
        PlayerPrefs.SetInt("canMove", 1);
        StartCoroutine("waitForLevelUp");
        
    }
}
