using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Entity.Concrete
{
    public class TeacherAvailability
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public TimeSpan Time { get; set; }
        public EnumDay DayOfWeek { get; set; }

    }

    public enum EnumDay
    {
        Pazartesi=1, Salı=2, Çarşamba=3, Perşembe=4, Cuma=5, Cumartesi=6, Pazar=7
    }
}
