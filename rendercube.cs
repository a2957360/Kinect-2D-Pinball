using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rendercube : MonoBehaviour {

    public List<GameObject> cube;
    public GameObject dodge;
    public Text showtime;
    float rendtime = 0;
    float time = 0;
    float count = 0;
    // Use this for initialization
    void Start () {
        renderCube();
        renderCube();
    }
	
	// Update is called once per frame
	void Update () {
        if (!CubemanController2D.gameover && CubemanController2D.gamestart)
        {
            rendtime += Time.deltaTime;
            time += Time.deltaTime;
            showtime.text = ((int)time).ToString();
            if (rendtime % 5 <= 1 && rendtime > 1)
            {
                count++;
                if (count == 2)
                {
                    renderdodge();
                    count = 0;
                }
                rendtime = 0;
                renderCube();
                renderCube();
            }
        }

    }

    void renderCube()
    {
        GameObject newcube = Instantiate(cube[Random.Range(0, cube.Count - 1)], new Vector3(Random.Range(-6.5f,6.5f), Random.Range(1.5f, 5.5f),0), new Quaternion(0,0,0,0));
        newcube.SetActive(true);
    }

    void renderdodge()
    {
        GameObject newcube = Instantiate(dodge, new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(1.5f, 5.5f), 0), new Quaternion(0, 0, 0, 0));
        newcube.SetActive(true);
    }
}
