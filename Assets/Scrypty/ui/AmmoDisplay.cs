using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public playershoot weapon;
    public TextMeshProUGUI text;
    
    void Start()
    {
        UpdateAmmoText();
    }
    
    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        text.text = $"Ammo:                   {weapon.currentClip} / {weapon.maxClipSize} | {weapon.currentAmmo} / {weapon.maxAmmoSize}";
    }
}
