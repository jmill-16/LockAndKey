using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bossHealtDisplay : MonoBehaviour
{
    public float bossHeatlh;
    public GameObject healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossHeatlh = GetComponent<EnemyHealth>().health;
        healthText.GetComponent<TextMeshPro>().text = bossHeatlh.ToString();
    }
}
