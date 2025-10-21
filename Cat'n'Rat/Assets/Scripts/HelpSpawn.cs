using UnityEngine;

public class HelpSpawn : MonoBehaviour
{
    public float queTime=5f;
    private float time = 0;
    public GameObject Help;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time>queTime)
        {
            GameObject go = Instantiate(Help);

            time = 0;

            Destroy(go, 15);
        }

        time += Time.deltaTime;
    }
}
