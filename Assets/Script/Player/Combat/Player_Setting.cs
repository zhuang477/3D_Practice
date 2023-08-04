using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Setting : MonoBehaviour
{
    public int health;
    public float stamina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/**public class Player_2D_Status : MonoBehaviour
{
    public int basic_health =100;
    public float basic_stamina =100;

    public TMP_Text StaminaShown;

    private float time = 0f;
    public bool inAction = false;

    // Update is called once per frame
    void Update()
    {
        StaminaShown.text = basic_stamina.ToString();
        StaminaRecover();
    }

    public void StaminaRecover()
    {
        time += Time.deltaTime;

        if (basic_stamina > 100)
        {
            basic_stamina = 100;
        }
        if(basic_stamina < 0)
        {
            basic_stamina = 0;
        }

        if (basic_stamina < 100 && inAction ==false)
        {
            if (time >= 0.2f)
            {
                basic_stamina += 2f;
                time = 0f;
            }
        }

    }
}**/
}
