using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorual_7.Models;
using Tutorual_7.Models.DTOs.Request;

namespace Tutorual_7.Service
{
    public interface ITripDbService
    {
        public List<Trip> GetTripList();
        public void DeleteClient(DeleteClientRequest request);
        public InsertClientResponse InsertStudent(InsertClientRequest request);
    }
}
