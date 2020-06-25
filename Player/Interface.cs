using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Slider healthSlider;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = player.health;
    }
}
