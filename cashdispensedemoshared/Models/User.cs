using System;

namespace cashdispensedemoshared.Models
{
    public class User
    {
        public User()
        {
            
        }

        public int UserId
        {
            get;
            set;
        }

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}
    }
}
