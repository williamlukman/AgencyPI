using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Constants
{
    public partial class Constant
    {
        public static string BaseContact = "BaseContact";
        public static TimeSpan PaymentDueDateTimeSpan = new TimeSpan(14, 0, 0);

        public class ControllerOutput
        {
            public static string PageViewNotAllowed = "You are not allowed to View this Page. <br/> <a href='/Authentication/Logout'>[Logout]</a>";
            public static string PagePrintNotAllowed = "You are not allowed to Print this Page. <br/> <a href='/Authentication/Logout'>[Logout]</a>";
            public static string ErrorPageHasNoClosingDate = "No report has been produced for this closing date.";
        }

        public class AgentPosition
        {
            public static int BusinessExecutive = 1;
            public static int BusinessPartner = 2;
        }

        public class ProspectStatus
        {
            public static int Prospect = 1;
            public static int Member = 2;
        }

        public class ProspectDetailNature
        {
            public static int UpdateAppointment = 1;
            public static int UpdateMeeting = 2;
            public static int UpdatePresentation = 3;
            public static int FollowUp = 4;
            public static int JoinFieldWork = 5;
            public static int Recruit = 6;
        }

        public class RecruitmentStatus
        {
            public static int JoinFieldWork = 1;
            public static int Recruit = 2;
        }

        public class GroupType
        {
            public static string Base = "Base";
        }

        public class UserType
        {
            public static string Admin = "Admin";
            public static string BusinessExecutive = "Business Executive";
            public static string BusinessPartner = "Business Partner";
        }

        public class MenuGroupName
        {
            public static string Agen = "Agen";
            public static string CalonProspect = "Calon Prospect";
            public static string Productivity = "Productivity";
            public static string Report = "Report";
            public static string Setting = "Setting";
        }

        public class MenuName
        {
            public static string Info = "My Info";
            public static string Leader = "My Leader";
            public static string Schedule = "My Schedule";
            
            public static string Prospect = "My Prospect";
            public static string JoinFieldWork = "Join Field of Work";
            public static string Recruit = "Recruit";

            public static string User = "User";
            public static string UserAccessRight = "User Access Right";
            public static string CompanyInfo = "Company Info";

            public static string WeeklyPresentation = "Presentasi per Minggu";
            public static string WeeklyUpdate = "Update Daftar Nama per Minggu";
            public static string WeeklyRecruitment = "Recruit per Minggu";
            public static string UnitProductivity = "Unit Productivity Report";
            public static string PersonalProductivity = "Personal Productivity Report";
        }
    }
}
