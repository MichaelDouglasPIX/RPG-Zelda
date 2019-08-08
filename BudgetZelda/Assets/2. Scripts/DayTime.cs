using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    float daySeconds;
    float radDay;
    public float daySpeed = 1;
    Light sunLight;
    float intensity;
    public Gradient ambient;

    public delegate void SunEvent();
    public SunEvent DawnCall;
    public SunEvent DuskCall;

    public static DayTime instance;
    bool day = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        sunLight = GetComponent<Light>();
        DawnCall += Afternoon;
        DuskCall += Morning;

    }
    //o dia tem 86400 segundos





    // Update is called once per frame
    void Update()
    {
        //segundos recebe os segundos * a velocidade
        daySeconds += Time.deltaTime * daySpeed;
        //divide o dia em duas partes 0 1
        radDay = daySeconds / (86400 / 2);
        //a cada uma interação troca o angulo 
        transform.localRotation = Quaternion.Euler(radDay * (180 / Mathf.PI), 0, 0);

        //Pega dois pontos, dois para baixo ou um para baixo e um para cima, dando 0 ou 1 para a intensidade
        intensity = Mathf.Clamp01(Vector3.Dot(transform.forward, Vector3.down) + 0.3f);
        sunLight.intensity = intensity;

        //Pega o rendere escolhido de 0 a 1 
        RenderSettings.ambientLight = ambient.Evaluate(intensity);

        //não deixa um fog vazando na cena
        RenderSettings.fogDensity = 0.001f * intensity;

        if (intensity > 0.4f && !day)
        {
            DuskCall();
            day = true;
        }

        if (intensity < 0.4f && day)
        {
            DawnCall();
            day = false;
        }

    }

    void Morning()
    {
        print("Good Morning!");
    }

    void Afternoon()
    {
        print("Good Night!");
    }
}