using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Image_Controller : MonoBehaviour
{
    Image image;

    private Player_HP playerhp;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        playerhp = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = playerhp.GetHP();
    }
}
