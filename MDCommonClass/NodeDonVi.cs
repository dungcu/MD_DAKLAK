using System;
using System.Collections.Generic;
using System.Text;

namespace MDSolution
{
    class NodeDonVi
    {
        private string mDonViID = "-1";
        private string mDonViName = "";
        private DonviType mType = DonviType.Root;
        private bool mHasLoadChildren = false;
        public bool HasLoadChildren
        {
            get { return mHasLoadChildren; }
            set { mHasLoadChildren = value; }
        }
        public NodeDonVi()
        { }
        public NodeDonVi(string strID, string strName, DonviType ttype)
        {
            this.mDonViID = strID;
            this.mDonViName = strName;
            this.mType = ttype;
        }
        public string DonViID
        {
            get { return mDonViID; }
            set { this.mDonViID = value; }
        }
        public string DonViName
        {
            get { return mDonViName; }
            set { this.mDonViName = value; }
        }
        public DonviType Type
        {
            get { return mType; }
            set { this.mType = value; }
        }
    }
    [Flags]
    public enum DonviType : int
    {
        Root = 0,
        Xa = 1,
        Thon = 2,
        ChuHopDong = 3,
        CuaHang=4,
        Cum = 5
    }
}
