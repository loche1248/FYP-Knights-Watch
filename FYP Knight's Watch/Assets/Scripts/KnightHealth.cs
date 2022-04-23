using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightHealth : MonoBehaviour
{
    public int health;
    public Slider healthBar;

    private void Update()
    {
        healthBar.value = health;
    }

}
