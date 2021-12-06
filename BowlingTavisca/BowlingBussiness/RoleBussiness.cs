using BowlingBussiness.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBussiness
{
   public class RoleBussiness : IRole
    {   
       
        public RoleBussiness()
        {
          
        }
        public int Role(int max)
        {
            Random random = new Random();
            return random.Next(max);           
        }
    }
}
