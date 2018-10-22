using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyFPS
{
    public class TeammateController : MonoBehaviour
    {
        public static UnityAction<Teammate> OnTeammateSelected;
        private Teammate _currentTeammate;
        private bool IsTeammate = false;

        public void SelectTeammate(Teammate teammate)
        {
            _currentTeammate = teammate;
            if (OnTeammateSelected != null)
                OnTeammateSelected(teammate);
        }

        public void MoveCommand()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {                
                Teammate _teammate = hit.collider.GetComponent<Teammate>();                

                if (_teammate)
                {
                    IsTeammate = true;
                    SelectTeammate(_teammate);
                }

                else if (_currentTeammate)
                {
                    IsTeammate = false;
                    _currentTeammate.SetDestination(hit.point);
                }
            }
        }

        public void OnGUI()
        {
            if(IsTeammate)
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width, Screen.height), "Now, she is your teammate");
        }
    }
}
