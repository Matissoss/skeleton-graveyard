using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text levelText;
    [SerializeField] private Text expText;
    [Header("Variables")]
    [SerializeField] private float currentExp;
    [SerializeField] private float neededExp;
    [SerializeField] private int level;
    private void Update()
    {
        level = PlayerPrefs.GetInt("level");
        currentExp = PlayerPrefs.GetFloat("currentExp");
        neededExp = PlayerPrefs.GetFloat("neededExp");
        levelText.text = "Level: " + level.ToString();
        expText.text = currentExp.ToString() + "/" + neededExp.ToString();
    }
}
