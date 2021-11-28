using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Player player;
    public Image currentHealthBar;

    public void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = player.health;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}
