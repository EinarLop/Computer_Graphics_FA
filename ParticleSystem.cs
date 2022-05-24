using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{

    public int N;
    List<GameObject> particles;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        particles = new List<GameObject>();
        for(int i =0; i<N; i++){
            GameObject go = new GameObject();
            go.AddComponent<Particle>();
            Particle p = go.GetComponent<Particle>();
            float x  = Random.Range(-5.0f,5.0f);
            float z  = Random.Range(-5.0f,5.0f);
            float y  = Random.Range(9.0f,11.0f);
            p.p = new Vector3(x,y,z);
            p.forces= Vector3.zero;
            p.forces.x = Random.Range(-1.0f,1.0f);
            p.forces.z = Random.Range(-1.0f,1.0f);

            p.r = Random.Range(0.2f, 0.4f);
            p.g = 5.81f;
            p.mass = p.r * 2.0f;
            p.rc = 0.4f;
            p.dragUp = 0.000001f;
            p.dragDown = 0.07f;

            particles.Add(go);
            Debug.Log(particles.Count);
    }
    }

    // Update is called once per frame
    void Update()
    {

          for(int i =0; i<N; i++){
                 Particle p = particles[i].GetComponent<Particle>();
                 bool iColl = false;
            for(int j = 0; j<N; j++){
                 Particle q = particles[j].GetComponent<Particle>();
                if(i != j){
                    bool c = p.CheckCollision(q);
                    if(c){
                        Debug.Log("HELLO");
                        color = new Color(1, 0, 0);
                        particles[i].GetComponent<Particle>().sph.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
                        particles[j].GetComponent<Particle>().sph.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
                        iColl = true;
                    }

                }
            
            }
            if(!iColl){
                particles[i].GetComponent<Particle>().sph.GetComponent<MeshRenderer>().material.SetColor("_Color", p.color);
            }
        }

    }
}

