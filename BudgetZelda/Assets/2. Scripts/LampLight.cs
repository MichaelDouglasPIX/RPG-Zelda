using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{

    public Light myLight;
    public Renderer RenderLight;


    // Start is called before the first frame update
    void Start()
    {

        DayTime.instance.DuskCall += TurnOff;
        DayTime.instance.DawnCall += TurnOn;


    }

    void TurnOn()
    {
        myLight.enabled = true;
        RenderLight.materials[1].EnableKeyword("_EMISSION");
    }

    void TurnOff()
    {
        myLight.enabled = false;
        RenderLight.materials[1].DisableKeyword("_EMISSION");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
