using Dreamteck.Splines;
using UnityEngine;

namespace Spline
{
    public class SplineTriggerManager : MonoBehaviour
    {
        /*
     * Needed Triggers at the points on the spline
     */
        SplineComputer _splineComputer;
        [SerializeField] GameObject _splineTriggerPrefab;
        private void Awake()
        {
            _splineComputer=GetComponent<SplineComputer>();
            MakeTriggers();
        }

        void MakeTriggers()
        {
            for (int i = _splineComputer.pointCount-1; i >= 0; i--)
            {
                GameObject temp = Instantiate(_splineTriggerPrefab,_splineComputer.GetPointPosition(i),Quaternion.identity);
                temp.GetComponent<SplineTrigger>().positionNumber = i;
            }
        }
    }
}
