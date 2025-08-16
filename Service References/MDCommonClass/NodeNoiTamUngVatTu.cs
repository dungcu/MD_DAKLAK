using System;
using System.Collections.Generic;
using System.Text;

namespace MDSolution
{
    class NodeNoiTamUngVatTu
    {
        private string mID = "-1";
        private string mName = "";


        public NodeNoiTamUngVatTu(string ID, string Name)
        {
            mID = ID;
            mName = Name;          
        }
        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }        
    }    
}
