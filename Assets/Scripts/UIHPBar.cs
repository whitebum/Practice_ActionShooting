using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour
{
    public Image barValueImage;
    public Creature target;

    private void Update()
    {
        if(target)
        {
            barValueImage.fillAmount = (float)target.hp / target.maxhp;
        }

        else
        {
            barValueImage.fillAmount = 0;
        }
    }
}
