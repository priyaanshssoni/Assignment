using System;
using Microsoft.Data.SqlClient;
using SIS.Model;

namespace SIS.Repository
{
	public interface iTeacherRepository
	{
        public int UpdateTeacherInfo(Teacher teacher);
        public Teacher DisplayTeacherInfo(Teacher teacher);
        public List<Course> GetAssignedCourses(Teacher teacher);
        public bool CheckIfTeacherIdExists(Teacher teacher);
      
        
    }
}

