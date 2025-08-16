using System;
using System.Collections.Generic;
using System.Text;

namespace MDSolution
{
    class NodeHopDongVanChuyen
    {
        private string mHopDongID = "-1";
        private string mHopDongName = "";
        private HDVCType mHopDongType = HDVCType.Root;
        private bool mHasLoadChildren = false;
        public bool HasLoadChildren
        {
            get { return mHasLoadChildren; }
            set { mHasLoadChildren = value; }
        }
        public NodeHopDongVanChuyen(string ID, string Name, HDVCType Type)
        {
            mHopDongID = ID;
            mHopDongName = Name;
            mHopDongType = Type;
        }
        public string HopDongID
        {
            get { return mHopDongID; }
            set { mHopDongID = value; }
        }
        public string HopDongName
        {
            get { return mHopDongName; }
            set { mHopDongName = value; }
        }
        public HDVCType  HopDongType
        {
            get { return mHopDongType; }
            set { mHopDongType = value; }
        }
    }
    [Flags]
    public enum HDVCType : int
    {
        Root = 0,
        HDVC = 1,
        XeVC = 2
    }
}
