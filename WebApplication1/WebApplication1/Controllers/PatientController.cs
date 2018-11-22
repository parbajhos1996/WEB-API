using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PatientController : ApiController
    {
        private static IList<Patient> PatientList = new List<Patient>();

        public IEnumerable<Patient> Get()
        {
            return PatientList;
        }

        public Patient Get(int id)
        {
            if (id >= 0 && id < PatientList.Count)
            {
                return PatientList[id];
            }

            return null;
        }

        public void Post([FromBody]Patient patient)
        {
            if (patient != null)
            {
                PatientList.Add(patient);
            }
        }

    }
}