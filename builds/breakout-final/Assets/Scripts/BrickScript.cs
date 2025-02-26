using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private Vector3 initialPos;

    private float timeOffset;

    public float noiseSpeed = 1f;
    public Vector3 movementDirection = Vector3.left;

    
    void Start()
    {

        
        initialPos = transform.position;

        timeOffset = Random.value + 10f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float noiseX = Mathf.PerlinNoise(timeOffset + Time.time * noiseSpeed, 0f);
        float xOffset = Map(noiseX,0f,1f,-1,1f);

        float noiseY = Mathf.PerlinNoise(0f, timeOffset + Time.time * noiseSpeed);
        float yOffset = Map(noiseY,0f,1f,-1,1f);

         float noiseZ = Mathf.PerlinNoise(timeOffset + Time.time * noiseSpeed, timeOffset + Time.time * noiseSpeed);
        float zOffset = Map(noiseZ,0f,1f,-1,1f);

        Vector3 noiseMovement = new Vector3 (xOffset, yOffset, zOffset);
        Vector3 movement = transform.position.normalized * noiseMovement.magnitude;

        transform.position = initialPos + movement;
        
    }

     public float Map(float valueOld, float oldMin, float oldMax, float newMin, float newMax)
    {
        float oldRange = oldMax - oldMin;
        float newRange = newMax - newMin;
        float valueOldPercent = (valueOld - oldMin) / oldRange;
        return newRange * valueOldPercent + newMin;
    }
}
