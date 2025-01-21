using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackApi
{
    public class Permission
    {
        public const string Base = "Base";

        public static AuthorizationPolicy BasePermission
            = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("employee_code")
                .RequireClaim("employee_firstname")
                .RequireClaim("employee_lastname")
                .RequireClaim("employee_branchid")
                .RequireClaim("employee_branchname")
                .Build();

        // TODO: หากมีการใช้ OAuth Persmission ให้ใส่ที่นี้

        public const string Monitor_User = "expensetrack_api:monitor_user";

        public static AuthorizationPolicy Monitor_UserPermission
            = new AuthorizationPolicyBuilder()
                .RequireClaim("permission", Monitor_User)
                .Build();

        public const string Monitor_Branch = "expensetrack_api:monitor_branch";

        public static AuthorizationPolicy Monitor_BranchPermission
            = new AuthorizationPolicyBuilder()
                .RequireClaim("permission", Monitor_Branch)
                .Build();

        public const string Monitor_Admin = "expensetrack_api:monitor_admin";

        public static AuthorizationPolicy Monitor_AdminPermission
            = new AuthorizationPolicyBuilder()
                .RequireClaim("permission", Monitor_Admin)
                .Build();
    }
}