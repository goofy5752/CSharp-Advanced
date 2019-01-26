namespace TelephonyProj
{
    public class Browse : IBrowsable
    {
        private string siteName;

        public Browse(string siteName)
        {
            this.SiteName = siteName;
        }

        public string SiteName
        {
            get
            {
                return siteName;
            }
            set
            {
                siteName = value;
            }
        }

        private bool IsValid()
        {
            string siteName = this.SiteName;
            foreach (var item in siteName)
            {
                if (char.IsDigit(item))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            if (IsValid())
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {this.SiteName}!";
            }
        }
    }
}