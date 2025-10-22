using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float queTime;
    private float time = 0;
    public GameObject obsticale;

    public int DieCount;

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

        
        if (queTime > 0.3f && DieCount == 10)
        {
            queTime = queTime-0.1f;
            Debug.Log("Que Is lower. "+queTime);
            DieCount = 0;
            
        }

        time += Time.deltaTime;
    }
}
