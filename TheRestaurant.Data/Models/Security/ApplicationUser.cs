using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TheRestaurant.Data.Generics;

namespace TheRestaurant.Data.Models.Security
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public string CNIC { get; set; }

        public string ILASPolicyResponse { get; set; }

        public AccessibilityType AccessibilityType { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsRemoteAllowed { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            userIdentity.AddClaim(new Claim("FullName", (this.FirstName + " " + this.LastName)));
            userIdentity.AddClaim(new Claim("UserType", (this.UserType.ToString())));
            userIdentity.AddClaim(new Claim("PhoneNumber", string.IsNullOrEmpty(this.PhoneNumber) == true ? "" : (this.PhoneNumber.ToString())));
            userIdentity.AddClaim(new Claim("CNIC", string.IsNullOrEmpty(this.CNIC) == true ? "" : (this.CNIC.ToString())));
            userIdentity.AddClaim(new Claim("AccessibilityType", (this.AccessibilityType == AccessibilityType.None ? "" : this.AccessibilityType.ToString())));

            //var LoginInfo = new LoginInfoHistory();
            //LoginInfo = LoginInfoTemp.GetCookieInfo();

            //if (LoginInfo.FK_Company_ID != 0)
            //{
                try
                {
                    //userIdentity.AddClaim(new Claim("_CompanyID", LoginInfo.FK_Company_ID.ToString()));
                    //userIdentity.AddClaim(new Claim("_CompanyType", ((int)LoginInfo.CompanyType).ToString()));
                    userIdentity.AddClaim(new Claim("_UserID", LoginInfo.FK_User_ID));
                    userIdentity.AddClaim(new Claim("_Name", this.UserName));
                    userIdentity.AddClaim(new Claim("_UserLoginPermissionCount", LoginInfo.UserLoginPermissionCount.ToString()));
                    userIdentity.AddClaim(new Claim("_UserLoginPermission", JsonConvert.SerializeObject(LoginInfo.UserLoginPermissionList)));
                    userIdentity.AddClaim(new Claim("_UserEmail", this.Email));
                }
                catch (Exception ex)
                {

                }
            //}

            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationUserViewModel : JQueryDtaTableOutput<ApplicationUserViewModel>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoggedIn { get; set; }
        public AccessibilityType AccessibilityType { get; set; }
    }
}