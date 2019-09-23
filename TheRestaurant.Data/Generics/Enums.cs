using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Data.Generics
{
    public enum UserType
    {
        Admin,
        Staff,
        User,
        Vender
    };

    public enum AccessibilityType
    {
        None,
        IsAdmin,
        IsUser,
        IsVender,
        IsStaff
    }
}
