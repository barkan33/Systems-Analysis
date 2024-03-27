using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems_Analysis
{
    public class Signature
    {
        private string signer;
        private DateTime timestamp;
        public Signature(string signer, DateTime timestamp)
        {
            SetSigner(signer);
            SetTimestamp(timestamp);
        }


        public string GetSigner()
        {
            return signer;
        }

        public void SetSigner(string signer)
        {
            this.signer = signer;
        }

        public DateTime GetTimestamp()
        {
            return timestamp;
        }

        public void SetTimestamp(DateTime timestamp)
        {
            this.timestamp = timestamp;
        }
    }
}
