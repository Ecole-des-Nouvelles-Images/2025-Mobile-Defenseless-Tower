using UnityEngine;
using UnityEngine.Serialization;

public class VfxSpawner : MonoBehaviour
{
    public GameObject PrefabParticle;

    public void SetUp(GameObject prefabParticle)
    {
        PrefabParticle = prefabParticle;
        GameObject particle = Instantiate(prefabParticle, transform.position, Quaternion.identity, transform);
        GameObject childParticle = particle.transform.GetChild(0).gameObject;
        Destroy(gameObject, childParticle.GetComponent<ParticleSystem>().main.duration);
    }
}
