using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float queTime=1.5f;
    private float time = 0;
    public GameObject obsticale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time>queTime)
        {
            GameObject go = Instantiate(obsticale);

            time = 0;

            Destroy(go, 15);
        }

        time += Time.deltaTime;
    }
}
