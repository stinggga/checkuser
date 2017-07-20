using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFio { get; set; }
        public string Password { get; set; }
        public double MeanSquareDeviation { get; set; }

    }
    public static class ValidateUser
    {        
        public  static List<User> GetDataFromDatabase()
        {

            return  new List<User>()
            {
                new User { UserId = 1, UserFio="user1" , Password="1234", MeanSquareDeviation = 252  },
                new User {  UserId = 2, UserFio="user2" , Password="1234", MeanSquareDeviation = 500  },
                new User {  UserId = 3, UserFio="user3" , Password="1234", MeanSquareDeviation = 400  }
            };
        }

        public static double GetMeanSquareDeviationFromColMilliseconds(List<int> colMilliseconds)
        {
            int len = colMilliseconds.Count();
            if (len == 0) return 0;

            double a = colMilliseconds.Average();

            double temp = 0;

            for (int i=0; i< len; i++)
            {
                temp = temp + Math.Pow((colMilliseconds[i] - a), 2);
            }
            return  Math.Sqrt(temp / len);
            //Среднее квадратичное отклонение
        }

        public static User GetUser(List<User> users,  double MeanSquareDeviation)
        {            
            int UserId = 0;
            
            double min_otkl = int.MaxValue;

            foreach (var user in users)
            {
                double otkl = Math.Abs(user.MeanSquareDeviation - MeanSquareDeviation);
                if (min_otkl > otkl)
                {
                    min_otkl = otkl;
                    UserId = user.UserId;
                }                
            }
            //if (min_otkl > 200)//если отлонение слишком большое 
            //    return null;                      
            return users.Where(x=> x.UserId == UserId).FirstOrDefault();
        }
    }
}
