using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    
    public Transform gorundPoint;
   public ObjectPooler[] groundPoolers;
   private float[] groundWidths;

   public Transform minHeightPoint;
   public Transform maxHeightPoint;

   private float minY;
   private float maxY;

   public float minGap;
   public float maxGap;

   private CoinGenerators coinGenerator;


    void Start()
    {
        minY = minHeightPoint.position.x;
        maxY = maxHeightPoint.position.y;


        groundWidths = new float[groundPoolers.Length];
        for(int i = 0; i<groundPoolers.Length; i++){
            groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        coinGenerator = FindObjectOfType<CoinGenerators>();
        
    }
 
    void Update()
    {
        if(transform.position.x < gorundPoint.position.x){
            int random= Random.Range(0,groundPoolers.Length);
            float distance = groundWidths[random]/2;
            float gap = Random.Range(minGap,maxGap);
            float height = Random.Range(minY,maxY);

            transform.position = new Vector3(
                transform.position.x + distance + gap,
                height,
                transform.position.z
            );

            GameObject ground = groundPoolers[random].GetPooledGameObject();
            ground.transform.position = transform.position;
            ground.SetActive(true);

            coinGenerator.SpawnCoins(
                transform.position,
                groundWidths[random]

            );

            transform.position = new Vector3(
                transform.position.x + distance,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
